using Android.Content;
using Android.Util;
using Android.Views;
using ViewPump.Inflation.ViewCreators;

namespace ViewPump.Inflation.Factories
{
    public class PrivateWrapperFactory2 : WrapperFactory2
    {
        #region Public Methods
        public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
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
        #endregion

        #region Constructors
        public PrivateWrapperFactory2(LayoutInflater.IFactory2 factory2, ViewPumpLayoutInflater inflater)
            : base(factory2)
        {
            ViewCreator = new PrivateWrapperFactory2ViewCreator(factory2, inflater);
        }
        #endregion
    }
}
