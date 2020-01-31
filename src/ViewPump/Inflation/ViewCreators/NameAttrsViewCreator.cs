using Android.Content;
using Android.Util;
using Android.Views;
using System;

namespace ViewPump.Inflation.ViewCreators
{
    public class NameAttrsViewCreator : IViewCreator
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
            foreach (var prefix in ViewPumpLayoutInflater.ClassPrefix)
            {
                try
                {
                    return LayoutInflater.CreateView(name, prefix, attrs);
                }
                catch (Exception)
                {
                    // Ignore.
                }
            }

            return LayoutInflater.SuperOnCreateView(name, attrs);
        }
        #endregion

        #region Constructors
        public NameAttrsViewCreator(ViewPumpLayoutInflater inflater)
        {
            LayoutInflater = inflater;
        }
        #endregion
    }
}
