using Android.Content.Res;
using Android.Graphics;
using Android.Util;
using AndroidX.CardView.Widget;
using ViewPump.Intercepting;

namespace Sample.App.Interceptors
{
    public class CardViewInterceptor : IInterceptor
    {
        public InflateResult Intercept(IChain chain)
        {
            var result = chain.Proceed();

            if (result.View is CardView cardView)
            {
                cardView.CardBackgroundColor = ColorStateList.ValueOf(Color.LightGray);
                cardView.Radius = TypedValue.ApplyDimension(ComplexUnitType.Dip, 10, Resources.System.DisplayMetrics);
            }

            return result;
        }
    }
}