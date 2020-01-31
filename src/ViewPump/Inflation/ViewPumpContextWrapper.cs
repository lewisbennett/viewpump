using Android.App;
using Android.Content;
using Android.Util;
using Android.Views;
using Java.Lang;

namespace ViewPump.Inflation
{
    public class ViewPumpContextWrapper : ContextWrapper
    {
        #region Properties
        /// <summary>
        /// Gets the layout inflater.
        /// </summary>
        private ViewPumpLayoutInflater Inflater { get; }
        #endregion

        #region Public Methods
        public override Object GetSystemService(string name)
        {
            if (name.Equals(LayoutInflaterService))
                return Inflater;

            return base.GetSystemService(name);
        }
        #endregion

        #region Constructors
        public ViewPumpContextWrapper(Context context)
            : base(context)
        {
            Inflater = new ViewPumpLayoutInflater(LayoutInflater.From(BaseContext), this);
        }
        #endregion

        #region Public Static Methods
        public static View OnActivityCreateView(Activity activity, View parent, View view, string name, Context context, IAttributeSet attrs)
        {
            if (!(activity.LayoutInflater is IViewPumpActivityFactory viewPumpActivityFactory))
                throw new System.Exception("This activity does not wrap the base context. Use ViewPumpContextWrapper.Wrap in your activity's OnAttachBaseContext method.");

            return viewPumpActivityFactory.OnActivityCreateView(parent, view, name, context, attrs);
        }

        public static ContextWrapper Wrap(Context @base)
        {
            return new ViewPumpContextWrapper(@base);
        }
        #endregion
    }
}
