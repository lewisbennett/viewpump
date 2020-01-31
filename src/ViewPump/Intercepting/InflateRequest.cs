using Android.Content;
using Android.Util;
using Android.Views;
using ViewPump.Inflation;

namespace ViewPump
{
    public sealed class InflateRequest
    {
        #region Properties
        /// <summary>
        /// Gets or sets the view attributes.
        /// </summary>
        public IAttributeSet Attrs { get; set; }

        /// <summary>
        /// Gets or sets the view context.
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        /// Gets or sets the fallback view creator.
        /// </summary>
        public IViewCreator FallbackViewCreator { get; set; }

        /// <summary>
        /// Gets or sets the name of the view.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent view, if any.
        /// </summary>
        public View Parent { get; set; }
        #endregion
    }
}
