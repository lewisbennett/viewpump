using Android.Graphics;
using Android.Widget;
using ViewPump.Intercepting;

namespace Sample.App.Interceptors
{
    public class TextViewInterceptor : IInterceptor
    {
        public InflateResult Intercept(IChain chain)
        {
            var result = chain.Proceed();

            if (!(result.View is TextView textView))
                return result;

            textView.SetTextAppearance(Resource.Style.Base_TextAppearance_AppCompat_Large);
            textView.SetTextColor(Color.Red);

            return result;
        }
    }
}