using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;
using ViewPump.Inflation;

namespace Sample.App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
        }

        protected override void AttachBaseContext(Context @base)
        {
            base.AttachBaseContext(ViewPumpContextWrapper.Wrap(@base));
        }
    }
}