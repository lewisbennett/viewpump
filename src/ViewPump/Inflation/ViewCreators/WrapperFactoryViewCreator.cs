using Android.Content;
using Android.Util;
using Android.Views;

namespace ViewPump.Inflation.ViewCreators
{
    public class WrapperFactoryViewCreator : IViewCreator
    {
        #region Properties
        /// <summary>
        /// Gets the factory.
        /// </summary>
        public LayoutInflater.IFactory Factory;
        #endregion

        #region Public Methods
        public View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            return Factory.OnCreateView(name, context, attrs);
        }
        #endregion

        #region Constructors
        public WrapperFactoryViewCreator(LayoutInflater.IFactory factory)
        {
            Factory = factory;
        }
        #endregion
    }
}
