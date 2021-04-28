using Android.Content;
using Android.Util;
using Android.Views;

namespace ViewPump.Base
{
    public interface IInterceptingDelegate
    {
        #region Methods
        /// <summary>
        /// Called before a view is inflated.
        /// </summary>
        /// <param name="context">The context that the view will be inflated in.</param>
        /// <param name="attrs">The attributes to apply to the view.</param>
        /// <param name="name">The fully qualified name of the view being inflated.</param>
        /// <param name="parent">The view's parent, if any.</param>
        bool OnInflateRequested(Context context, IAttributeSet attrs, string name, View parent);

        /// <summary>
        /// Called when a view has been inflated.
        /// </summary>
        /// <param name="context">The context that the view exists within.</param>
        /// <param name="attrs">The attributes applied to the view.</param>
        /// <param name="name">The fully qualified name of the view.</param>
        /// <param name="view">The inflated view.</param>
        void OnViewInflated(Context context, IAttributeSet attrs, string name, View view);
        #endregion
    }
}
