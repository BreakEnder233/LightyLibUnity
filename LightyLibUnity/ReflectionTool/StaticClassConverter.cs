using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightyLibUnity.ReflectionTool
{
    public static class StaticClassConverter
    {
        public static object ConvertTo(Type staticClass, Type targetClass)
        {
            var fields = targetClass.GetFields();
            var targetObject = targetClass.GetConstructor(new Type[] { }).Invoke(new object[] { });
            foreach(var field in fields)
            {
                var fieldName = field.Name;
                var sourceField = staticClass.GetField(fieldName, System.Reflection.BindingFlags.Static);
                if(sourceField.GetType() != field.GetType())
                {
                    continue;
                }
                field.SetValue(targetObject, sourceField.GetValue(null));
            }
            return targetObject;
        }
    }
}
