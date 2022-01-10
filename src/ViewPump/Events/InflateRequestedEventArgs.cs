using System;
using Android.Content;
using Android.Util;
using Android.Views;

namespace ViewPump.Events;

public class InflateRequestedEventArgs : EventArgs
{
    #region Properties
    /// <summary>
    /// Gets the context that the view will be inflated in.
    /// </summary>
    public Context Context { get; }

    /// <summary>
    /// Gets the attributes to apply to the view.
    /// </summary>
    public IAttributeSet Attrs { get; }

    /// <summary>
    /// Gets the fully qualified name of the view being inflated.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the view's parent, if any.
    /// </summary>
    public View Parent { get; }
    #endregion

    #region Constructors
    public InflateRequestedEventArgs(Context context, IAttributeSet attrs, string name, View parent)
    {
        Attrs = attrs;
        Context = context;
        Name = name;
        Parent = parent;
    }
    #endregion
}