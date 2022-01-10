using Android.Content;
using Android.Util;
using Android.Views;
using Java.Lang;
using ViewPump.ViewCreators;

namespace ViewPump.Infrastructure.Factories;

public class ViewPumpFactory : Object, LayoutInflater.IFactory
{
    #region Fields
    private readonly FactoryViewCreator _factoryViewCreator;
    #endregion

    #region Event Handlers
    /// <summary>
    /// Creates a view.
    /// </summary>
    /// <param name="name">The fully qualified name of the view being inflated.</param>
    /// <param name="context">The context that the view will be inflated in.</param>
    /// <param name="attrs">The attributes to apply to the view.</param>
    public View OnCreateView(string name, Context context, IAttributeSet attrs)
    {
        return InterceptingService.Instance.Inflate(_factoryViewCreator, context, attrs, name, null);
    }
    #endregion

    #region Constructors
    public ViewPumpFactory(LayoutInflater.IFactory factory)
    {
        _factoryViewCreator = new FactoryViewCreator(factory);
    }
    #endregion
}