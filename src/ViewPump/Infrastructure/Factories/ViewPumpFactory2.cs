using Android.Content;
using Android.Util;
using Android.Views;
using ViewPump.ViewCreators;

namespace ViewPump.Infrastructure.Factories
{
    public class ViewPumpFactory2 : Java.Lang.Object, LayoutInflater.IFactory2
    {
        #region Fields
        private readonly LayoutInflater.IFactory2 _factory2;
        private readonly Factory2ViewCreator _factory2ViewCreator;
        #endregion

        #region Event Handlers
        /// <summary>
        /// Creates a view.
        /// </summary>
        /// <param name="name">The fully qualified name of the view being inflated.</param>
        /// <param name="context">The context that the view will be inflated in.</param>
        /// <param name="attrs">The attributes to apply to the view.</param>
        public View OnCreateView(string name, Context context, IAttributeSet attrs)
        {
            return OnCreateView(null, name, context, attrs);
        }

        /// <summary>
        /// Creates a view.
        /// </summary>
        /// <param name="parent">The view's parent, if any.</param>
        /// <param name="name">The fully qualified name of the view being inflated.</param>
        /// <param name="context">The context that the view will be inflated in.</param>
        /// <param name="attrs">The attributes to apply to the view.</param>
        public View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            return InterceptingService.Instance.Inflate(_factory2ViewCreator, context, attrs, name, parent);
        }
        #endregion

        #region Constructors
        public ViewPumpFactory2(LayoutInflater.IFactory2 factory2)
            : base()
        {
            _factory2 = factory2;

            _factory2ViewCreator = new Factory2ViewCreator(_factory2);
        }
        #endregion
    }
}
