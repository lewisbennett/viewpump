using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using Google.Android.Material.TextField;
using ViewPump.Base;

namespace Sample.App;

public class InterceptingDelegate : IInterceptingDelegate
{
    #region Event Handlers
    /// <inheritdoc />
    public bool OnInflateRequested(Context context, IAttributeSet attrs, string name, View parent)
    {
        // Return true to allow every view to be inflated.
        // False can also be returned which will prevent the view from being inflated, but may result in unexpected behaviour.
        return true;
    }

    /// <inheritdoc />
    public void OnViewInflated(Context context, IAttributeSet attrs, string name, View view)
    {
        switch (view)
        {
            // Modify CardView's.
            case CardView cardView:

                cardView.CardBackgroundColor = ColorStateList.ValueOf(Color.LightGray);
                cardView.Radius = TypedValue.ApplyDimension(ComplexUnitType.Dip, 10, Resources.System.DisplayMetrics);

                return;

            // Modify EditText's.
            case EditText editText:

                var states = new[]
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

                if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                    editText.CompoundDrawableTintList = colorStateList;

                editText.SetTextColor(Color.Black);

                if (editText is TextInputEditText textInputEditText)
                    textInputEditText.SupportBackgroundTintList = colorStateList;

                return;

            // Modify TextInputLayout's.
            case TextInputLayout textInputLayout:

                var hintStates = new[]
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

                return;

            // Modify TextView's.
            case TextView textView:

                if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                    textView.SetTextAppearance(Resource.Style.Base_TextAppearance_AppCompat_Large);

                textView.SetTextColor(Color.Red);

                return;
        }
    }
    #endregion
}