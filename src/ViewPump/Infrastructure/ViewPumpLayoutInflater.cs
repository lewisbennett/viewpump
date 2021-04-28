using Android.Content;
using Android.Util;
using Android.Views;
using System.Xml;

namespace ViewPump.Infrastructure
{
    public class ViewPumpLayoutInflater : LayoutInflater
    {
        #region Event Handlers
        /// <summary>
        /// This routine is for creating the correct subclass of View given the XML element name.
        /// </summary>
        /// <param name="name">The fully qualified class name of the View to be created.</param>
        /// <param name="attrs">An AttributeSet of attributes to apply to the View.</param>
        protected override View OnCreateView(string name, IAttributeSet attrs)
        {
            return InterceptingService.Instance.Inflate(Context, attrs, name, null);
        }

        /// <summary>
        /// Version of <see cref="LayoutInflater.OnCreateView(string?, IAttributeSet?)" /> that also takes the future parent of the view being constructed.
        /// </summary>
        /// <param name="parent">The future parent of the returned view. Note that this may be null.</param>
        /// <param name="name">The fully qualified class name of the View to be created.</param>
        /// <param name="attrs">An AttributeSet of attributes to apply to the View.</param>
        protected override View OnCreateView(View parent, string name, IAttributeSet attrs)
        {
            return InterceptingService.Instance.Inflate(Context, attrs, name, parent);
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
        /// Inflate a new view hierarchy from the specified XML resource.
        /// </summary>
        /// <param name="resource">ID for an XML layout resource to load (e.g. Resource.Layout.main_page).</param>
        /// <param name="root">Optional view to be the parent of the generated hierarchy (if <paramref name="attachToRoot"/> is <c>true</c>), or else simply an object that provides a set of <see cref="ViewGroup.LayoutParams" /> for root of the returned hierarchy (if <paramref name="attachToRoot" /> is <c>false</c>).</param>
        /// <param name="attachToRoot">Whether the inflated hierarchy should be attached to the root parameter. If <c>false</c>, <paramref name="root" /> is only used to create the correct subclass of <see cref="ViewGroup.LayoutParams" /> for the root view in the XML.</param>
        public override View Inflate(int resource, ViewGroup root, bool attachToRoot)
        {
            var view = base.Inflate(resource, root, attachToRoot);

            if (view != null && )
                // Set tag stuff

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
            // Set something.

            return base.Inflate(parser, root, attachToRoot);
        }
        #endregion

        #region Constructors
        internal ViewPumpLayoutInflater(LayoutInflater original, Context context)
            : base(original, context)
        {
        }
        #endregion
    }
}
