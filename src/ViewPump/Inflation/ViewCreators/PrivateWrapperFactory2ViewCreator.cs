using Android.Content;
using Android.Util;
using Android.Views;

namespace ViewPump.Inflation.ViewCreators
{
    public class PrivateWrapperFactory2ViewCreator : WrapperFactory2ViewCreator
    {
        #region Properties
        /// <summary>
        /// Gets the layout inflater.
        /// </summary>
        public ViewPumpLayoutInflater Inflater { get; protected set; }
        #endregion

        #region Public Methods
        public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            return Inflater.CreateCustomViewInternal(Factory2.OnCreateView(parent, name, context, attrs), name, context, attrs);
        }
        #endregion

        #region Constructors
        public PrivateWrapperFactory2ViewCreator(LayoutInflater.IFactory2 factory2, ViewPumpLayoutInflater inflater)
            : base(factory2)
        {
            Inflater = inflater;
        }
        #endregion
    }
}
