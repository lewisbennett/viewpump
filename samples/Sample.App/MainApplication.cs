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

            InterceptingService.Init();

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