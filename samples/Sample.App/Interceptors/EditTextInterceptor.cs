using Android.Content.Res;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Widget;
using ViewPump.Intercepting;

namespace Sample.App.Interceptors
{
    public class EditTextInterceptor : IInterceptor
    {
        public InflateResult Intercept(IChain chain)
        {
            var result = chain.Proceed();

            if (!(result.View is EditText editText))
                return result;

            var states = new int[][]
            {
                new[] { Android.Resource.Attribute.StateFocused },
                new[] { -Android.Resource.Attribute.StateFocused }
            };

            var colors = new int[]
            {
                Color.Green,
                Color.Green
            };

            var colorStateList = new ColorStateList(states, colors);

            editText.BackgroundTintList = colorStateList;
            editText.CompoundDrawableTintList = colorStateList;

            editText.SetTextColor(Color.Black);

            if (editText is TextInputEditText textInputEditText)
                textInputEditText.SupportBackgroundTintList = colorStateList;

            return result;
        }
    }
}