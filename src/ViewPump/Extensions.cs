using System;
using System.Diagnostics;
using System.Reflection;

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
        public static bool TryInvokeMethod(this MethodInfo method, object target, params object[] args)
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
        public static bool TrySet(this FieldInfo field, object target, object value)
        {
            try
            {
                field.SetValue(target, value);

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
