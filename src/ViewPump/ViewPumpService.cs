namespace ViewPump
{
    public static class ViewPumpService
    {
        #region Properties
        /// <summary>
        /// Gets the current ViewPumpService, if any.
        /// </summary>
        public static IViewPumpService Instance { get; private set; }
        #endregion

        #region Public Methods
        public static void Init()
        {
            Instance = new ViewPumpServiceImpl();
        }

        public static void Init(IViewPumpService viewPumpService)
        {
            Instance = viewPumpService;
        }
        #endregion
    }
}
