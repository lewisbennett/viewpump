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

            ViewPumpService.Instance.Interceptors.Add(new CardViewInterceptor());
            ViewPumpService.Instance.Interceptors.Add(new EditTextInterceptor());
            ViewPumpService.Instance.Interceptors.Add(new TextInputLayoutInterceptor());
            ViewPumpService.Instance.Interceptors.Add(new TextViewInterceptor());
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