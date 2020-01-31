<div align="center">

[![GitHub license](https://img.shields.io/badge/license-Apache%202-blue.svg?style=flat-square)](https://raw.githubusercontent.com/lewisbennett/viewpump/master/README.md)

</div>

# ViewPump

Intercept the view inflation process using [InflationX' ViewPump](https://github.com/InflationX/ViewPump) Android library in Xamarin.

ViewPump allows you to intercept the view inflation process. This allows you to customise views on an app-wide scale without having to create sub-classes (although these are supported) both before and after the view itself has been inflated.

## Getting Started

Get started by calling `ViewPump.ViewPumpService.Init()`. `Init()` has overflow methods where you can provide your own `IViewPumpService` should you wish to do so.

In each of your Activity's you must override the protected method `AttachBaseContext` to allow ViewPump to wrap the context:
```
protected override void AttachBaseContext(Context @base)
{
    base.AttachBaseContext(ViewPumpContextWrapper.Wrap(@base));
}
```

## Intercepting

To begin intercepting, implement `ViewPump.Intercepting.IInterceptor`. You'll then have access to the `Intercept` method. When this method is called the view hasn't yet been inflated. To inflate the view simply call on the provided `ViewPump.Intercepting.IChain`:
```
public InflateResult Intercept(IChain chain)
{
    // The view has not yet been inflated.

    var result = chain.Proceed();
    
    // The view has been inflated.
    
    return result;
}
```
View the sample project for examples.
