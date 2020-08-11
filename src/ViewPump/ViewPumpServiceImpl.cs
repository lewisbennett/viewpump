using System.Collections.Generic;
using ViewPump.Inflation;
using ViewPump.Intercepting;

namespace ViewPump
{
    public class ViewPumpServiceImpl : IViewPumpService
    {
        #region Fields
        private readonly List<IInterceptor> _interceptors = new List<IInterceptor>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets whether custom view creation is enabled.
        /// </summary>
        public bool CustomViewCreation { get; set; } = true;

        /// <summary>
        /// Gets the active interceptors.
        /// </summary>
        public IInterceptor[] Interceptors
        {
            get
            {
                lock (_interceptors)
                    return _interceptors.ToArray();
            }
        }

        /// <summary>
        /// Gets or sets whether to enable private factory injection.
        /// </summary>
        public bool PrivateFactoryInjection { get; set; } = true;

        /// <summary>
        /// Gets or sets an IFallbackViewCreator used to instantiate a view via reflection.
        /// </summary>
        public IViewCreator ReflectiveFallbackViewCreator { get; set; } = new ReflectiveFallbackViewCreator();

        /// <summary>
        /// Gets or sets whether to store the layout resource ID in the view tag.
        /// </summary>
        public bool StoreLayoutResID { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds an interceptor.
        /// </summary>
        /// <param name="interceptor">The interceptor to add.</param>
        public void AddInterceptor(IInterceptor interceptor)
        {
            if (!_interceptors.Contains(interceptor))
                _interceptors.Add(interceptor);
        }

        /// <summary>
        /// Submits an InflateRequest to be inflated.
        /// </summary>
        /// <param name="inflateRequest">The inflater view request.</param>
        public InflateResult Inflate(InflateRequest inflateRequest)
            => new InterceptorChain(new List<IInterceptor>(Interceptors) { new FallbackViewCreationInterceptor() }, 0, inflateRequest).Proceed(inflateRequest);

        /// <summary>
        /// Removes an interceptor.
        /// </summary>
        /// <param name="interceptor">The interceptor to remove.</param>
        public void RemoveInterceptor(IInterceptor interceptor)
            => _interceptors.Remove(interceptor);
        #endregion
    }
}
