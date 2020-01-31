using System.Collections.Generic;

namespace ViewPump.Intercepting
{
    public class InterceptorChain : IChain
    {
        #region Fields
        private readonly IList<IInterceptor> _interceptors;
        private readonly int _index;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the inflate request.
        /// </summary>
        public InflateRequest InflateRequest { get; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Proceeds with the current request.
        /// </summary>
        public InflateResult Proceed()
        {
            return Proceed(InflateRequest);
        }

        /// <summary>
        /// Proceeds with a specific request.
        /// </summary>
        /// <param name="inflateRequest">The inflate request.</param>
        public InflateResult Proceed(InflateRequest inflateRequest)
        {
            return _interceptors[_index].Intercept(new InterceptorChain(_interceptors, _index + 1, inflateRequest));
        }
        #endregion

        #region Constructors
        public InterceptorChain(IList<IInterceptor> interceptors, int index, InflateRequest request)
        {
            _interceptors = interceptors;
            _index = index;

            InflateRequest = request;
        }
        #endregion
    }
}
