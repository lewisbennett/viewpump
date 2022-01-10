using Android.Content;
using Android.Util;
using Android.Views;
using ViewPump.Infrastructure;

namespace ViewPump.ViewCreators.Base;

public abstract class BaseViewCreator : IViewCreator
{
    #region Properties
    /// <summary>
    /// Gets the <see cref="ViewPumpLayoutInflater" />.
    /// </summary>
    public ViewPumpLayoutInflater LayoutInflater { get; }
    #endregion

    #region Event Handlers
    /// <summary>
    /// Creates a view.
    /// </summary>
    /// <param name="parent">The view's parent, if any.</param>
    /// <param name="name">The fully qualified name of the view being inflated.</param>
    /// <param name="context">The context that the view will be inflated in.</param>
    /// <param name="attrs">The attributes to apply to the view.</param>
    public abstract View OnCreateView(View parent, string name, Context context, IAttributeSet attrs);
    #endregion

    #region Constructors
    protected BaseViewCreator(ViewPumpLayoutInflater layoutInflater)
    {
        LayoutInflater = layoutInflater;
    }
    #endregion
}