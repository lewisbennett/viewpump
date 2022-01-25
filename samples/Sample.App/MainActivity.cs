using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;
using ViewPump;

namespace Sample.App;

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
        // In order for ViewPump to intercept the view inflation process, we must wrap the
        // activity's context in one managed by the intercepting service.
        // A good option here would be to include this in a BaseActivity file, that all of
        // your activities then inherit from.
        base.AttachBaseContext(InterceptingService.Instance.WrapContext(@base));
    }
}