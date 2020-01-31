using Android.Content;
using Android.Util;
using Android.Views;
using Java.Lang.Reflect;
using System;
using JL_Class = Java.Lang.Class;
using JL_Object = Java.Lang.Object;

namespace ViewPump.Inflation
{
    public class ReflectiveFallbackViewCreator : IViewCreator
    {
        #region Public Methods
        public View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            try
            {
                var clazz = JL_Class.ForName(name).AsSubclass(JL_Class.FromType(typeof(View)));

                Constructor constructor = null;

                try
                {
                    constructor = clazz.GetConstructor(ConstructorSignatureTwo);
                    return constructor.NewInstance(context, attrs as JL_Object) as View;
                }
                catch (Java.Lang.NoSuchMethodException)
                {
                    constructor = clazz.GetConstructor(ConstructorSignatureOne);
                    return constructor.NewInstance(context) as View;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not create view: {name}: {e.ToString()}");
            }

            return null;
        }
        #endregion

        #region Constant Values
        public static readonly JL_Class[] ConstructorSignatureOne = new[] { JL_Class.FromType(typeof(Context)) };
        public static readonly JL_Class[] ConstructorSignatureTwo = new[] { JL_Class.FromType(typeof(Context)), JL_Class.FromType(typeof(IAttributeSet)) };
        #endregion
    }
}
