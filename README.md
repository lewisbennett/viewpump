[![License: Apache](https://img.shields.io/badge/License-Apache-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![GitHub forks](https://img.shields.io/nuget/dt/ViewPump.svg)](https://www.nuget.org/packages/ViewPump/)

# ViewPump

ViewPump allows you to intercept the view inflation process. This library allows you to customize views on an app-wide scale without having to create sub-classes (although these are supported), both before and after the view itself has been inflated.

Heavily based upon [InflationX' ViewPump](https://github.com/InflationX/ViewPump).

## Getting Started

Install ViewPump from [NuGet](https://www.nuget.org/packages/ViewPump/), or add a reference to `ViewPump`.

At the entry point for your app, call `ViewPump.InterceptingService.Init(...)`. You can optionally provide your own [`IInterceptingService`](https://github.com/lewisbennett/viewpump/blob/release-1.0.0/src/ViewPump/Base/IInterceptingService.cs) implementation.

## Intercepting

The view inflation process can be intercepted with two methods:

### Events

`IInterceptingService` provides two events: [`InflateRequested`](https://github.com/lewisbennett/viewpump/blob/release-1.0.0/src/ViewPump/Base/IInterceptingService.cs#L13), and [`ViewInflated`](https://github.com/lewisbennett/viewpump/blob/release-1.0.0/src/ViewPump/Base/IInterceptingService.cs#L14).

`InflateRequested` is triggered before a view is inflated, and `ViewInflated` is triggered after a view has been inflated. Both events provide custom event arguments that give you relevant information per the event. See [Events](https://github.com/lewisbennett/viewpump/tree/release-1.0.0/src/ViewPump/Events).

### [IInterceptingDelegate](https://github.com/lewisbennett/viewpump/blob/release-1.0.0/src/ViewPump/Base/IInterceptingDelegate.cs)

You can optionally provide an `IInterceptingDelegate` implementation by doing the following:

```
ViewPump.InterceptingService.Delegate = new MyCustomInterceptingDelegate();
```

The delegate gives you methods that provide you with the same information as the aforementioned events. The key difference, though, is that [`IInterceptingDelegate.OnInflateRequested`](https://github.com/lewisbennett/viewpump/blob/release-1.0.0/src/ViewPump/Base/IInterceptingDelegate.cs#L17) returns a `bool`. This allows you to deny the inflation of particular views however, there may be side effects as a result of doing so.

## [Android sample project](https://github.com/lewisbennett/viewpump/tree/release-1.0.0/samples/Sample.App)
