using ViewPump.Infrastructure;

namespace ViewPump
{
    public static class InterceptingService
    {
        #region Properties
        /// <summary>
        /// Gets the intercepting service instance.
        /// </summary>
        public static IInterceptingService Instance => InterceptingServiceCore.Instance;
        #endregion

        #region Public Methods
        /// <summary>
        /// Initialize the intercepting service.
        /// </summary>
        public static void Init()
        {
            Init(new ViewPumpInterceptingService());
        }

        /// <summary>
        /// Initialize the intercepting service.
        /// </summary>
        /// <param name="interceptingService">A custom intercepting service.</param>
        public static void Init(IInterceptingService interceptingService)
        {
            InterceptingServiceCore.Instance = interceptingService;
        }
        #endregion
    }
}
