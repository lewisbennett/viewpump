using Android.Content.Res;
using Android.Graphics;
using Google.Android.Material.TextField;
using ViewPump.Intercepting;

namespace Sample.App.Interceptors
{
    public class TextInputLayoutInterceptor : IInterceptor
    {
        public InflateResult Intercept(IChain chain)
        {
            var result = chain.Proceed();

            if (result.View is TextInputLayout textInputLayout)
            {
                var hintStates = new int[][]
            {
                new[] { Android.Resource.Attribute.StateFocused },
                new[] { -Android.Resource.Attribute.StateFocused }
            };

                var hintColors = new int[]
                {
                Color.Green,
                Color.Gray
                };

                textInputLayout.DefaultHintTextColor = new ColorStateList(hintStates, hintColors);
            }

            return result;
        }
    }
}