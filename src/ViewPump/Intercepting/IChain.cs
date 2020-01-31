namespace ViewPump.Intercepting
{
    public interface IChain
    {
        #region Properties
        /// <summary>
        /// Gets the inflate request.
        /// </summary>
        InflateRequest InflateRequest { get; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Proceeds with the current request.
        /// </summary>
        InflateResult Proceed();

        /// <summary>
        /// Proceeds with a specific request.
        /// </summary>
        /// <param name="inflateRequest">The inflate request.</param>
        InflateResult Proceed(InflateRequest inflateRequest);
        #endregion
    }
}
