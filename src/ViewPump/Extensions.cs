using Java.Lang.Reflect;
using System;
using System.Diagnostics;
using Java_Object = Java.Lang.Object;

namespace ViewPump
{
    public static class Extensions
    {
        #region Public Methods
        /// <summary>
        /// Tries to invoke a method.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="args">The method parameters.</param>
        public static bool TryInvoke(this Method method, Java_Object target, params Java_Object[] args)
        {
            try
            {
                method.Invoke(target, args);

                return true;
            }
            catch (Exception e)
            {
                // Ignore, but log.
                Debug.WriteLine($"Could not invoke method {method.Name}: {e}");

                return false;
            }
        }

        /// <summary>
        /// Tries to set the value of the field.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="value">The value to set.</param>
        public static bool TrySet(this Field field, Java_Object target, Java_Object value)
        {
            try
            {
                field.Set(target, value);

                return true;
            }
            catch (Exception e)
            {
                // Ignore, but log.
                Debug.WriteLine($"Could not set value for field {field.Name}: {e}");

                return false;
            }
        }
        #endregion
    }
}
