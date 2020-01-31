namespace ViewPump.Intercepting
{
    public class FallbackViewCreationInterceptor : IInterceptor
    {
        #region Public Methods
        /// <summary>
        /// Intercepts the inflation process.
        /// </summary>
        /// <param name="chain">The inflation chain.</param>
        public InflateResult Intercept(IChain chain)
        {
            var request = chain.InflateRequest;
            var fallbackView = request.FallbackViewCreator.OnCreateView(request.Parent, request.Name, request.Context, request.Attrs);

            return new InflateResult
            {
                View = fallbackView,
                Name = fallbackView?.Class?.Name ?? request.Name,
                Context = request.Context,
                Attrs = request.Attrs
            };
        }
        #endregion
    }
}
