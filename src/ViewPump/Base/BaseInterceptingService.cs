using ViewPump.Intercepting;

namespace ViewPump.Base
{
    public abstract class BaseInterceptingService : IInterceptingService
    {
        #region Fields
        private readonly List<IInterceptor> _interceptors = new();
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds an interceptor.
        /// </summary>
        /// <param name="interceptor">The interceptor.</param>
        public void AddInterceptor(IInterceptor interceptor)
        {
            if (!_interceptors.Contains(interceptor))
            {
                lock (_interceptors)
                    _interceptors.Add(interceptor);
            }
        }

        /// <summary>
        /// Gets the interceptors that are registered with the service.
        /// </summary>
        public IInterceptor[] GetInterceptors()
        {
            lock (_interceptors)
                return _interceptors.ToArray();
        }

        /// <summary>
        /// Removes an interceptor.
        /// </summary>
        /// <param name="interceptor">The interceptor.</param>
        public void RemoveInterceptor(IInterceptor interceptor)
        {
            if (_interceptors.Contains(interceptor))
            {
                lock (_interceptors)
                    _interceptors.Remove(interceptor);
            }
        }
        #endregion
    }
}
