using Android.Content;
using ViewPump.Base;

namespace ViewPump.Infrastructure;

public class ViewPumpInterceptingService : BaseInterceptingService
{
    #region Public Methods
    /// <summary>
    ///     Provides a <see cref="ContextWrapper" /> for the supplied <see cref="Context" />.
    /// </summary>
    /// <param name="context">The context to wrap.</param>
    public override ContextWrapper WrapContext(Context context)
    {
        return new ViewPumpContextWrapper(context);
    }
    #endregion
}