using Android.Content;
using Android.Util;
using Android.Views;

namespace ViewPump.Inflation.ViewCreators
{
    public class ActivityViewCreator : IViewCreator
    {
        #region Properties
        private readonly View _view;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the layout inflater.
        /// </summary>
        public ViewPumpLayoutInflater LayoutInflater { get; }
        #endregion

        #region Public Methods
        public View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            return LayoutInflater.CreateCustomViewInternal(_view, name, context, attrs);
        }
        #endregion

        #region Constructors
        public ActivityViewCreator(ViewPumpLayoutInflater inflater, View view)
        {
            _view = view;

            LayoutInflater = inflater;
        }
        #endregion
    }
}
