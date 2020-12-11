using Android.App;
using Android.Runtime;
using Sample.App.Interceptors;
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

            ViewPumpService.Init();

            ViewPumpService.Instance.AddInterceptor(new CardViewInterceptor());
            ViewPumpService.Instance.AddInterceptor(new EditTextInterceptor());
            ViewPumpService.Instance.AddInterceptor(new TextInputLayoutInterceptor());
            ViewPumpService.Instance.AddInterceptor(new TextViewInterceptor());
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