using ViewPump.Base;
using ViewPump.Infrastructure;

namespace ViewPump
{
    public static class InterceptingService
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether or not to enable custom view creation.
        /// </summary>
        public static bool CustomViewCreation { get; set; } = true;

        /// <summary>
        /// Gets or sets the intercepting delegate, if any.
        /// </summary>
        public static IInterceptingDelegate Delegate
        {
            get => InterceptingServiceCore.Delegate;

            set => InterceptingServiceCore.Delegate = value;
        }

        /// <summary>
        /// Gets the intercepting service instance.
        /// </summary>
        public static IInterceptingService Instance => InterceptingServiceCore.Instance;

        /// <summary>
        /// Gets or sets whether or not to enable private factory injection.
        /// </summary>
        public static bool PrivateFactoryInjection { get; set; } = true;

        /// <summary>
        /// Gets or sets whether or not to store the layout resource ID as the tag on inflated views.
        /// </summary>
        public static bool StoreLayoutResID { get; set; }
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
