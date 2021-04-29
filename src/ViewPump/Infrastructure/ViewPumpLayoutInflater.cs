﻿using Android.Content;
using Android.OS;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang.Reflect;
using System.Xml;
using ViewPump.Infrastructure.Factories;
using ViewPump.ViewCreators;
using Java_Class = Java.Lang.Class;
using Java_Object = Java.Lang.Object;

namespace ViewPump.Infrastructure
{
    public class ViewPumpLayoutInflater : LayoutInflater
    {
        #region Fields
        private readonly NameViewCreator _nameViewCreator;
        private readonly ParentNameViewCreator _parentNameViewCreator;
        private bool _hasSetPrivateFactory;
        #endregion

        #region Event Handlers
        /// <summary>
        /// This routine is for creating the correct subclass of View given the XML element name.
        /// </summary>
        /// <param name="name">The fully qualified class name of the View to be created.</param>
        /// <param name="attrs">An AttributeSet of attributes to apply to the View.</param>
        protected override View OnCreateView(string name, IAttributeSet attrs)
        {
            return InterceptingService.Instance.Inflate(_nameViewCreator, Context, attrs, name, null);
        }

        /// <summary>
        /// Version of <see cref="LayoutInflater.OnCreateView(string?, IAttributeSet?)" /> that also takes the future parent of the view being constructed.
        /// </summary>
        /// <param name="parent">The future parent of the returned view. Note that this may be null.</param>
        /// <param name="name">The fully qualified class name of the View to be created.</param>
        /// <param name="attrs">An AttributeSet of attributes to apply to the View.</param>
        protected override View OnCreateView(View parent, string name, IAttributeSet attrs)
        {
            return InterceptingService.Instance.Inflate(_parentNameViewCreator, Context, attrs, name, parent);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Invokes the base routine for creating the correct subclass of View given the XML element name.
        /// </summary>
        /// <param name="name">The fully qualified class name of the View to be created.</param>
        /// <param name="attrs">An AttributeSet of attributes to apply to the View.</param>
        public View BaseOnCreateView(string name, IAttributeSet attrs)
        {
            try
            {
                return base.OnCreateView(name, attrs);
            }
            catch
            {
                // Ignore.
                return null;
            }
        }

        /// <summary>
        /// Base version of <see cref="LayoutInflater.OnCreateView(string?, IAttributeSet?)" /> that also takes the future parent of the view being constructed.
        /// </summary>
        /// <param name="parent">The future parent of the returned view. Note that this may be null.</param>
        /// <param name="name">The fully qualified class name of the View to be created.</param>
        /// <param name="attrs">An AttributeSet of attributes to apply to the View.</param>
        public View BaseOnCreateView(View parent, string name, IAttributeSet attrs)
        {
            try
            {
                return base.OnCreateView(parent, name, attrs);
            }
            catch
            {
                // Ignore.
                return null;
            }
        }

        /// <summary>
        /// Create a copy of the existing layout inflater object, with the copy pointing to a different Context than the original.
        /// </summary>
        /// <param name="newContext">The new Context to associate with the new LayoutInflater. May be the same as the original Context if desired.</param>
        public override LayoutInflater CloneInContext(Context newContext)
        {
            return new ViewPumpLayoutInflater(this, newContext);
        }

        /// <summary>
        /// Inflates a custom view.
        /// </summary>
        /// <param name="view">A previous attempt at inflating the view using factories, or null.</param>
        /// <param name="name">The fully qualified class name of the View to be created.</param>
        /// <param name="context">The context that the view will be inflated in.</param>
        /// <param name="attrs">An AttributeSet of attributes to apply to the View.</param>
        public virtual View InflateCustomView(View view, string name, Context context, IAttributeSet attrs)
        {
            // If the view has already been created, or the view name doesn't seem to be a subclass, return the view/null.
            if (!InterceptingService.CustomViewCreation || view != null || (name != null && !name.Contains('.')))
                return view;

            // Create the view differently if on or above Android Q.
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Q)
                return CloneInContext(context).CreateView(name, null, attrs);

            if (Java_Class.FromType(typeof(LayoutInflater)).GetDeclaredField("mConstructorArgs") is Field field)
            {
                field.Accessible = true;

                var constructorArgs = (Java_Object[])field.Get(this);

                var previousContext = constructorArgs[0];
                constructorArgs[0] = context;

                field.TrySet(this, constructorArgs);

                try
                {
                    view = CreateView(name, null, attrs);
                }
                catch
                {
                    // Ignore.
                }

                constructorArgs[0] = previousContext;

                field.TrySet(this, constructorArgs);
            }

            return view;
        }

        /// <summary>
        /// Inflate a new view hierarchy from the specified XML resource.
        /// </summary>
        /// <param name="resource">ID for an XML layout resource to load (e.g. Resource.Layout.main_page).</param>
        /// <param name="root">Optional view to be the parent of the generated hierarchy (if <paramref name="attachToRoot"/> is <c>true</c>), or else simply an object that provides a set of <see cref="ViewGroup.LayoutParams" /> for root of the returned hierarchy (if <paramref name="attachToRoot" /> is <c>false</c>).</param>
        /// <param name="attachToRoot">Whether the inflated hierarchy should be attached to the root parameter. If <c>false</c>, <paramref name="root" /> is only used to create the correct subclass of <see cref="ViewGroup.LayoutParams" /> for the root view in the XML.</param>
        public override View Inflate(int resource, ViewGroup root, bool attachToRoot)
        {
            var view = base.Inflate(resource, root, attachToRoot);

            if (view != null && InterceptingService.StoreLayoutResID)
                view.SetTag(Resource.Id.viewpump_layout_res, resource);

            return view;
        }

        /// <summary>
        /// Inflate a new view hierarchy from the specified XML node.
        /// </summary>
        /// <param name="parser">XML dom node containing the description of the view hierarchy.</param>
        /// <param name="root">Optional view to be the parent of the generated hierarchy (if <paramref name="attachToRoot"/> is <c>true</c>), or else simply an object that provides a set of <see cref="ViewGroup.LayoutParams" /> for root of the returned hierarchy (if <paramref name="attachToRoot" /> is <c>false</c>).</param>
        /// <param name="attachToRoot">Whether the inflated hierarchy should be attached to the root parameter. If <c>false</c>, <paramref name="root" /> is only used to create the correct subclass of <see cref="ViewGroup.LayoutParams" /> for the root view in the XML.</param>
        public override View Inflate(XmlReader parser, ViewGroup root, bool attachToRoot)
        {
            if (!_hasSetPrivateFactory && InterceptingService.PrivateFactoryInjection)
            {
                if (Context is IFactory2 factory2)
                {
                    var setPrivateFactoryMethod = Java_Class.FromType(typeof(LayoutInflater)).GetMethod("setPrivateFactory", Java_Class.FromType(typeof(IFactory2)));

                    setPrivateFactoryMethod.Accessible = true;

                    setPrivateFactoryMethod.TryInvoke(this, new PrivateViewPumpFactory2(factory2, this));
                }

                _hasSetPrivateFactory = true;
            }

            return base.Inflate(parser, root, attachToRoot);
        }

        /// <summary>
        /// Sets the <see cref="LayoutInflater.IFactory" />.
        /// </summary>
        /// <param name="factory">The factory</param>
        [Export("setFactory")]
        public void SetFactory(IFactory factory)
        {
            Factory = factory is ViewPumpFactory ? factory : new ViewPumpFactory(factory);
        }

        /// <summary>
        /// Sets the <see cref="LayoutInflater.IFactory2" />.
        /// </summary>
        /// <param name="factory2">The factory.</param>
        [Export("setFactory2")]
        public void SetFactory2(IFactory2 factory2)
        {
            Factory2 = factory2 is ViewPumpFactory2 ? factory2 : new ViewPumpFactory2(factory2);
        }
        #endregion

        #region Constructors
        internal ViewPumpLayoutInflater(LayoutInflater original, Context context)
            : base(original, context)
        {
            _nameViewCreator = new NameViewCreator(this);
            _parentNameViewCreator = new ParentNameViewCreator(this);
        }
        #endregion
    }
}
