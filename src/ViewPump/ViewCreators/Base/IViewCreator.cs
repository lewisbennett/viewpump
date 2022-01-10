using Android.Content;
using Android.Util;
using Android.Views;

namespace ViewPump.ViewCreators.Base;

public interface IViewCreator
{
    #region Methods
    /// <summary>
    ///     Creates a view.
    /// </summary>
    /// <param name="parent">The view's parent, if any.</param>
    /// <param name="name">The fully qualified name of the view being inflated.</param>
    /// <param name="context">The context that the view will be inflated in.</param>
    /// <param name="attrs">The attributes to apply to the view.</param>
    View OnCreateView(View parent, string name, Context context, IAttributeSet attrs);
    #endregion
}