using Android.Content;
using Android.Util;
using Android.Views;

namespace ViewPump.Intercepting
{
    public sealed class InflateResult
    {
        #region Properties
        /// <summary>
        /// Gets or sets the view attributes.
        /// </summary>
        public IAttributeSet Attrs { get; set; }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        /// Gets or sets the name of the view.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public View View { get; set; }
        #endregion
    }
}
