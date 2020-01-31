using System.Collections.Generic;
using ViewPump.Inflation;
using ViewPump.Intercepting;

namespace ViewPump
{
    public class ViewPumpServiceImpl : IViewPumpService
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether custom view creation is enabled.
        /// </summary>
        public bool CustomViewCreation { get; set; } = true;

        /// <summary>
        /// Gets the active interceptors.
        /// </summary>
        public IList<IInterceptor> Interceptors { get; } = new List<IInterceptor>();

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
        /// Submits an InflateRequest to be inflated.
        /// </summary>
        /// <param name="inflateRequest">The inflater view request.</param>
        public InflateResult Inflate(InflateRequest inflateRequest)
        {
            return new InterceptorChain(new List<IInterceptor>(Interceptors) { new FallbackViewCreationInterceptor() }, 0, inflateRequest).Proceed(inflateRequest);
        }
        #endregion
    }
}
