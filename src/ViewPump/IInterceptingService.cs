using ViewPump.Intercepting;

namespace ViewPump
{
    public interface IInterceptingService
    {
        #region Methods
        /// <summary>
        /// Adds an interceptor.
        /// </summary>
        /// <param name="interceptor">The interceptor.</param>
        void AddInterceptor(IInterceptor interceptor);

        /// <summary>
        /// Gets the interceptors that are registered with the service.
        /// </summary>
        IInterceptor[] GetInterceptors();

        /// <summary>
        /// Removes an interceptor.
        /// </summary>
        /// <param name="interceptor">The interceptor.</param>
        void RemoveInterceptor(IInterceptor interceptor);
        #endregion
    }
}
