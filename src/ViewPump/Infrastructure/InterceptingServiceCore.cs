using ViewPump.Base;

namespace ViewPump.Infrastructure;

public static class InterceptingServiceCore
{
    #region Properties
    /// <summary>
    ///     Gets or sets the intercepting delegate, if any.
    /// </summary>
    public static IInterceptingDelegate Delegate { get; set; }

    /// <summary>
    ///     Gets the intercepting service instance
    /// </summary>
    public static IInterceptingService Instance { get; internal set; }
    #endregion
}