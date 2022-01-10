using Android.Content;
using Android.Util;
using Android.Views;
using Java.Lang;
using ViewPump.ViewCreators;

namespace ViewPump.Infrastructure.Factories;

public class PrivateViewPumpFactory2 : Object, LayoutInflater.IFactory2
{
    #region Fields
    private readonly PrivateFactory2ViewCreator _privateFactoryViewCreator;
    #endregion

    #region Constructors
    public PrivateViewPumpFactory2(LayoutInflater.IFactory2 factory2, ViewPumpLayoutInflater layoutInflater)
    {
        _privateFactoryViewCreator = new PrivateFactory2ViewCreator(layoutInflater, factory2);
    }
    #endregion

    #region Event Handlers
    /// <summary>
    ///     Creates a view.
    /// </summary>
    /// <param name="name">The fully qualified name of the view being inflated.</param>
    /// <param name="context">The context that the view will be inflated in.</param>
    /// <param name="attrs">The attributes to apply to the view.</param>
    public View OnCreateView(string name, Context context, IAttributeSet attrs)
    {
        return OnCreateView(null, name, context, attrs);
    }

    /// <summary>
    ///     Creates a view.
    /// </summary>
    /// <param name="parent">The view's parent, if any.</param>
    /// <param name="name">The fully qualified name of the view being inflated.</param>
    /// <param name="context">The context that the view will be inflated in.</param>
    /// <param name="attrs">The attributes to apply to the view.</param>
    public View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
    {
        return InterceptingService.Instance.Inflate(_privateFactoryViewCreator, context, attrs, name, parent);
    }
    #endregion
}