using System.Collections.Generic;
using ViewPump.Inflation;
using ViewPump.Intercepting;

namespace ViewPump
{
    public interface IViewPumpService
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether custom view creation is enabled.
        /// </summary>
        bool CustomViewCreation { get; set; }

        /// <summary>
        /// Gets the active interceptors.
        /// </summary>
        IList<IInterceptor> Interceptors { get; }

        /// <summary>
        /// Gets or sets whether to enable private factory injection.
        /// </summary>
        bool PrivateFactoryInjection { get; set; }

        /// <summary>
        /// Gets or sets an IFallbackViewCreator used to instantiate a view via reflection.
        /// </summary>
        IViewCreator ReflectiveFallbackViewCreator { get; set; }

        /// <summary>
        /// Gets or sets whether to store the layout resource ID in the view tag.
        /// </summary>
        bool StoreLayoutResID { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Submits an InflateRequest to be inflated.
        /// </summary>
        /// <param name="inflateRequest">The inflater view request.</param>
        InflateResult Inflate(InflateRequest inflateRequest);
        #endregion
    }
}
