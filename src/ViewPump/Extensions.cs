using Java.Lang.Reflect;
using System;
using System.Linq;
using JL_Class = Java.Lang.Class;
using JL_Object = Java.Lang.Object;

namespace ViewPump
{
    public static class Extensions
    {
        #region Public Methods
        /// <summary>
        /// Gets an accessible method, or null.
        /// </summary>
        /// <param name="methodName">The name of the method.</param>
        public static Method GetAccessibleMethod(this JL_Class @class, string methodName)
        {
            if (@class == null || string.IsNullOrWhiteSpace(methodName))
                return null;

            var method = @class.GetMethods().FirstOrDefault(m => m.Name.Equals(methodName));

            if (method != null)
                method.Accessible = true;

            return method;
        }

        /// <summary>
        /// Safely invokes a method.
        /// </summary>
        public static void SafeInvokeMethod(this Method method, JL_Object target, params JL_Object[] args)
        {
            if (method == null)
                return;

            try
            {
                method.Invoke(target, args);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not invoke method {method.Name}: {e.ToString()}");
            }
        }

        /// <summary>
        /// Sets the value of a field safely.
        /// </summary>
        public static void SafeSet(this Field field, JL_Object obj, JL_Object value)
        {
            try
            {
                field.Set(obj, value);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not set value for field {field.Name}: {e.ToString()}");
            }
        }
        #endregion
    }
}
