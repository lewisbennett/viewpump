using Android.Content;
using Android.Util;
using Android.Views;

namespace ViewPump.Inflation
{
    public interface IViewCreator
    {
        #region Public Methods
        View OnCreateView(View parent, string name, Context context, IAttributeSet attrs);
        #endregion
    }
}
