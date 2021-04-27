namespace ViewPump.Infrastructure
{
    public static class InterceptingServiceCore
    {
        #region Properties
        /// <summary>
        /// Gets the intercepting service instance
        /// </summary>
        public static IInterceptingService Instance { get; internal set; }
        #endregion
    }
}
