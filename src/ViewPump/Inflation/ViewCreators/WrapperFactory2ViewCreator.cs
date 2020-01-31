using Android.Content;
using Android.Util;
using Android.Views;

namespace ViewPump.Inflation.ViewCreators
{
    public class WrapperFactory2ViewCreator : IViewCreator
    {
        #region Properties
        /// <summary>
        /// Gets the factory.
        /// </summary>
        public LayoutInflater.IFactory2 Factory2 { get; }
        #endregion

        #region Public Methods
        public virtual View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            return Factory2.OnCreateView(parent, name, context, attrs);
        }
        #endregion

        #region Constructors
        public WrapperFactory2ViewCreator(LayoutInflater.IFactory2 factory2)
        {
            Factory2 = factory2;
        }
        #endregion
    }
}
