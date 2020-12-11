using Android.Content;
using Android.OS;
using Android.Util;
using Android.Views;
using Java.Interop;
using System;
using System.Xml;
using ViewPump.Inflation.Factories;
using ViewPump.Inflation.ViewCreators;
using static ViewPump.Resource;
using JL_Class = Java.Lang.Class;
using JL_Object = Java.Lang.Object;

namespace ViewPump.Inflation
{
    public class ViewPumpLayoutInflater : LayoutInflater, IViewPumpActivityFactory
    {
        #region Fields
        private bool _setPrivateFactory;
        #endregion

        #region Properties
        /// <summary>
        /// Gets whether the Android version is at least Android 10/Q.
        /// </summary>
        public bool IsAtLeastQ => Build.VERSION.SdkInt > BuildVersionCodes.P;

        /// <summary>
        /// Gets the name and attributes view creator.
        /// </summary>
        public NameAttrsViewCreator NameAttrsViewCreator { get; }

        /// <summary>
        /// Gets the parent, name and attributes view creator.
        /// </summary>
        public ParentNameAttrsViewCreator ParentNameAttrsViewCreator { get; }
        #endregion

        #region Public Methods
        public override LayoutInflater CloneInContext(Context newContext)
        {
            return new ViewPumpLayoutInflater(this, newContext);
        }

        public View CreateCustomViewInternal(View view, string name, Context viewContext, IAttributeSet attrs)
        {
            if (!ViewPumpService.Instance.CustomViewCreation || view != null || !name.Contains("."))
                return view;

            if (IsAtLeastQ)
                return CloneInContext(viewContext).CreateView(name, null, attrs);

            var field = JL_Class.FromType(typeof(LayoutInflater)).GetDeclaredField("mConstructorArgs");

            if (field == null)
                return view;

            field.Accessible = true;

            var constructorArgs = (JL_Object[])field.Get(this);

            var lastContext = constructorArgs[0];
            constructorArgs[0] = viewContext;

            field.SafeSet(this, constructorArgs);

            try
            {
                view = CreateView(name, null, attrs);
            }
            catch (Exception)
            {
                // Ignore.
            }
            finally
            {
                constructorArgs[0] = lastContext;
                field.SafeSet(this, constructorArgs);
            }

            return view;
        }

        protected override View OnCreateView(View parent, string name, IAttributeSet attrs)
        {
            return ViewPumpService.Instance.Inflate(new InflateRequest
            {
                Attrs = attrs,
                Context = Context,
                FallbackViewCreator = ParentNameAttrsViewCreator,
                Name = name,
                Parent = parent

            }).View;
        }

        protected override View OnCreateView(string name, IAttributeSet attrs)
        {
            return ViewPumpService.Instance.Inflate(new InflateRequest
            {
                Attrs = attrs,
                Context = Context,
                FallbackViewCreator = NameAttrsViewCreator,
                Name = name

            }).View;
        }

        public override View Inflate(int resource, ViewGroup root, bool attachToRoot)
        {
            var view = base.Inflate(resource, root, attachToRoot);

            if (view != null && ViewPumpService.Instance.StoreLayoutResID)
                view.SetTag(Id.viewpump_layout_res, resource);

            return view;
        }

        public override View Inflate(XmlReader parser, ViewGroup root, bool attachToRoot)
        {
            SetPrivateFactoryInternal();

            var view = base.Inflate(parser, root, attachToRoot);

            return view;
        }

        public View OnActivityCreateView(View parent, View view, string name, Context context, IAttributeSet attrs)
        {
            return ViewPumpService.Instance.Inflate(new InflateRequest
            {
                Attrs = attrs,
                Context = context,
                FallbackViewCreator = new ActivityViewCreator(this, view),
                Name = name,
                Parent = parent

            }).View;
        }

        [Export]
        public void setFactory(IFactory factory)
        {
            if (!(factory is WrapperFactory))
            {
                Factory = new WrapperFactory(factory);
                return;
            }

            Factory = factory;
        }

        [Export]
        public void setFactory2(IFactory2 factory2)
        {
            if (!(factory2 is WrapperFactory2))
            {
                Factory2 = new WrapperFactory2(factory2);
                return;
            }

            Factory = factory2;
        }

        public View SuperOnCreateView(View parent, string name, IAttributeSet attrs)
        {
            try
            {
                var view = base.OnCreateView(parent, name, attrs);

                return view;
            }
            catch (Exception)
            {
                // Ignore.
                return null;
            }
        }

        public View SuperOnCreateView(string name, IAttributeSet attrs)
        {
            try
            {
                var view = base.OnCreateView(name, attrs);

                return view;
            }
            catch (Exception)
            {
                // Ignore.
                return null;
            }
        }
        #endregion

        #region Constructors
        public ViewPumpLayoutInflater(LayoutInflater original, Context context)
            : base(original, context)
        {
            NameAttrsViewCreator = new NameAttrsViewCreator(this);
            ParentNameAttrsViewCreator = new ParentNameAttrsViewCreator(this);
        }
        #endregion

        #region Private Methods
        private void SetPrivateFactoryInternal()
        {
            if (_setPrivateFactory || !ViewPumpService.Instance.PrivateFactoryInjection)
                return;

            if (!(Context is IFactory2))
            {
                _setPrivateFactory = true;
                return;
            }

            JL_Class.FromType(typeof(LayoutInflater)).GetAccessibleMethod("setPrivateFactory").SafeInvokeMethod(this, new PrivateWrapperFactory2(Context as IFactory2, this));
            _setPrivateFactory = true;
        }
        #endregion

        #region Constant Values
        public static readonly string[] ClassPrefix = new[] { "android.app.", "android.widget.", "android.webkit." };
        #endregion
    }
}
