using Android.App;
using Android.Runtime;
using System;
using ViewPump;

namespace Sample.App
{
    [Application]
    public class MainApplication : Application
    {
        public override void OnCreate()
        {
            base.OnCreate();

            // Initialize the intercepting service.
            InterceptingService.Init();

            // Provide the intercepting service with a custom intercepting delegate.
            // This allows us to be notified when views are about to be, and after they have been inflated.
            // The delegate also allows us to control whether certain views should be allowed to be inflated.
            InterceptingService.Delegate = new InterceptingDelegate();
        }

        public MainApplication()
            : base()
        {
        }

        public MainApplication(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
    }
}