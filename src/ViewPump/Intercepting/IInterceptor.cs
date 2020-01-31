namespace ViewPump.Intercepting
{
    public interface IInterceptor
    {
        #region Public Methods
        /// <summary>
        /// Intercepts the inflation process.
        /// </summary>
        /// <param name="chain">The inflation chain.</param>
        InflateResult Intercept(IChain chain);
        #endregion
    }
}
