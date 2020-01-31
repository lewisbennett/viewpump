using Android.Content;
using Android.Util;
using Android.Views;
using ViewPump.Inflation.ViewCreators;

namespace ViewPump.Inflation.Factories
{
    public class WrapperFactory : Java.Lang.Object, LayoutInflater.IFactory
    {
        #region Properties
        /// <summary>
        /// Gets the factory.
        /// </summary>
        public LayoutInflater.IFactory Factory { get; protected set; }

        /// <summary>
        /// Gets the view creator.
        /// </summary>
        public IViewCreator ViewCreator { get; protected set; }
        #endregion

        #region Public Methods
        public View OnCreateView(string name, Context context, IAttributeSet attrs)
        {
            return ViewPumpService.Instance.Inflate(new InflateRequest
            {
                Attrs = attrs,
                Context = context,
                FallbackViewCreator = ViewCreator,
                Name = name

            }).View;
        }
        #endregion

        #region Constructors
        public WrapperFactory(LayoutInflater.IFactory factory)
        {
            Factory = factory;
            ViewCreator = new WrapperFactoryViewCreator(Factory);
        }
        #endregion
    }
}
