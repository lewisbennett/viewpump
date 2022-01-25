using Android.Content;
using Android.Views;
using Java.Lang;

namespace ViewPump.Infrastructure
{
    public class ViewPumpContextWrapper : ContextWrapper
    {
        #region Fields
        private ViewPumpLayoutInflater _viewPumpLayoutInflater;
        #endregion

        #region Public Methods
        /// <summary>
        /// Return the handle to a system-level service by name.
        /// </summary>
        /// <param name="name">The name of the desired service.</param>
        public override Object GetSystemService(string name)
        {
            if (name != null && name.Equals(LayoutInflaterService))
                return _viewPumpLayoutInflater ??= new ViewPumpLayoutInflater(LayoutInflater.FromContext(BaseContext), this);

            return base.GetSystemService(name);
        }
        #endregion

        #region Constructors
        internal ViewPumpContextWrapper(Context context)
            : base(context)
        {
        }
        #endregion
    }
}
