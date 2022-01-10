using Android.Content;
using Android.Util;
using Android.Views;
using ViewPump.Infrastructure;
using ViewPump.ViewCreators.Base;

namespace ViewPump.ViewCreators;

public class PrivateFactory2ViewCreator : BaseViewCreator
{
    #region Fields
    private readonly LayoutInflater.IFactory2 _factory2;
    #endregion

    #region Event Handlers
    /// <summary>
    /// Creates a view.
    /// </summary>
    /// <param name="parent">The view's parent, if any.</param>
    /// <param name="name">The fully qualified name of the view being inflated.</param>
    /// <param name="context">The context that the view will be inflated in.</param>
    /// <param name="attrs">The attributes to apply to the view.</param>
    public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
    {
        return LayoutInflater.InflateCustomView(parent, _factory2.OnCreateView(parent, name, context, attrs), name, context, attrs);
    }
    #endregion

    #region Constructors
    public PrivateFactory2ViewCreator(ViewPumpLayoutInflater layoutInflater, LayoutInflater.IFactory2 factory2)
        : base(layoutInflater)
    {
        _factory2 = factory2;
    }
    #endregion
}