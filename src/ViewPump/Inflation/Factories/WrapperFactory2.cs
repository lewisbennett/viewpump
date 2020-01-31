using Android.Content;
using Android.Util;
using Android.Views;
using ViewPump.Inflation.ViewCreators;

namespace ViewPump.Inflation.Factories
{
    public class WrapperFactory2 : Java.Lang.Object, LayoutInflater.IFactory2
    {
        #region Properties
        /// <summary>
        /// Gets the factory.
        /// </summary>
        public LayoutInflater.IFactory2 Factory { get; protected set; }

        /// <summary>
        /// Gets the view creator.
        /// </summary>
        public IViewCreator ViewCreator { get; protected set; }
        #endregion

        #region Public Methods
        public virtual View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            return ViewPumpService.Instance.Inflate(new InflateRequest
            {
                Attrs = attrs,
                Context = context,
                FallbackViewCreator = ViewCreator,
                Name = name,
                Parent = parent

            }).View;
        }

        public virtual View OnCreateView(string name, Context context, IAttributeSet attrs)
        {
            return OnCreateView(null, name, context, attrs);
        }
        #endregion

        #region Constructors
        public WrapperFactory2(LayoutInflater.IFactory2 factory2)
        {
            Factory = factory2;
            ViewCreator = new WrapperFactory2ViewCreator(Factory);
        }
        #endregion
    }
}
