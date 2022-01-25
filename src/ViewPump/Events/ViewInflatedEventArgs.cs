using Android.Content;
using Android.Util;
using Android.Views;
using System;

namespace ViewPump.Events;

public class ViewInflatedEventArgs : EventArgs
{
    #region Properties
    /// <summary>
    /// Gets the context that the view exists within.
    /// </summary>
    public Context Context { get; }

    /// <summary>
    /// Gets the attributes applied to the view.
    /// </summary>
    public IAttributeSet Attrs { get; }

    /// <summary>
    /// Gets the fully qualified name of the inflated view.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the inflated view.
    /// </summary>
    public View View { get; }
    #endregion

    #region Constructors
    public ViewInflatedEventArgs(Context context, IAttributeSet attrs, string name, View view)
    {
        Attrs = attrs;
        Context = context;
        Name = name;
        View = view;
    }
    #endregion
}