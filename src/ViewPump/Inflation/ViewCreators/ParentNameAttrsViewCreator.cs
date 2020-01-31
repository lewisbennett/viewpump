using Android.Content;
using Android.Util;
using Android.Views;

namespace ViewPump.Inflation.ViewCreators
{
    public class ParentNameAttrsViewCreator : IViewCreator
    {
        #region Properties
        /// <summary>
        /// Gets the layout inflater.
        /// </summary>
        public ViewPumpLayoutInflater LayoutInflater { get; }
        #endregion

        #region Public Methods
        public View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            return LayoutInflater.SuperOnCreateView(parent, name, attrs);
        }
        #endregion

        #region Constructors
        public ParentNameAttrsViewCreator(ViewPumpLayoutInflater inflater)
        {
            LayoutInflater = inflater;
        }
        #endregion
    }
}
