using Android.Content;
using Android.Util;
using Android.Views;

namespace ViewPump.Inflation
{
    public interface IViewPumpActivityFactory
    {
        #region Public Methods
        View OnActivityCreateView(View parent, View view, string name, Context context, IAttributeSet attrs);
        #endregion
    }
}
