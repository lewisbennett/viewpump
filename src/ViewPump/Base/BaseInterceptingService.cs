using System;
using Android.Content;
using Android.Util;
using Android.Views;
using ViewPump.Events;
using ViewPump.ViewCreators.Base;

namespace ViewPump.Base;

public abstract class BaseInterceptingService : IInterceptingService
{
    #region Events
    public event EventHandler<InflateRequestedEventArgs> InflateRequested;
    public event EventHandler<ViewInflatedEventArgs> ViewInflated;
    #endregion

    #region Public Methods
    /// <summary>
    /// Inflates a view.
    /// </summary>
    /// <param name="viewCreator">The <see cref="IViewCreator" /> in charge of creating the view.</param>
    /// <param name="context">The context that the view will be inflated in</param>
    /// <param name="attrs">The attributes to apply to the view</param>
    /// <param name="name">The fully qualified name of the view being inflated.</param>
    /// <param name="parent">The view's parent, if any.</param>
    public virtual View Inflate(IViewCreator viewCreator, Context context, IAttributeSet attrs, string name, View parent)
    {
        InflateRequested?.Invoke(this, new InflateRequestedEventArgs(context, attrs, name, parent));

        if (InterceptingService.Delegate != null && !InterceptingService.Delegate.OnInflateRequested(context, attrs, name, parent) || viewCreator.OnCreateView(parent, name, context, attrs) is not { } view)
            return null;
        
        // Try to assign the correct view name for the benefit of the below events.
        name = view.Class.Name;

        ViewInflated?.Invoke(this, new ViewInflatedEventArgs(context, attrs, name, view));

        InterceptingService.Delegate?.OnViewInflated(context, attrs, name, view);

        return view;
    }

    /// <summary>
    /// Provides a <see cref="ContextWrapper" /> for the supplied <see cref="Context" />.
    /// </summary>
    /// <param name="context">The context to wrap.</param>
    public abstract ContextWrapper WrapContext(Context context);
    #endregion
}