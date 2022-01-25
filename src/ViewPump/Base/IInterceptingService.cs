using System;
using Android.Content;
using Android.Util;
using Android.Views;
using ViewPump.Events;
using ViewPump.ViewCreators.Base;

namespace ViewPump.Base;

public interface IInterceptingService
{
    #region Events
    event EventHandler<InflateRequestedEventArgs> InflateRequested;
    event EventHandler<ViewInflatedEventArgs> ViewInflated;
    #endregion

    #region Methods
    /// <summary>
    ///     Inflates a view.
    /// </summary>
    /// <param name="viewCreator">The <see cref="IViewCreator" /> in charge of creating the view.</param>
    /// <param name="context">The context that the view will be inflated in</param>
    /// <param name="attrs">The attributes to apply to the view</param>
    /// <param name="name">The fully qualified name of the view being inflated.</param>
    /// <param name="parent">The view's parent, if any.</param>
    View Inflate(IViewCreator viewCreator, Context context, IAttributeSet attrs, string name, View parent);

    /// <summary>
    ///     Provides a <see cref="ContextWrapper" /> for the supplied <see cref="Context" />.
    /// </summary>
    /// <param name="context">The context to wrap.</param>
    ContextWrapper WrapContext(Context context);
    #endregion
}