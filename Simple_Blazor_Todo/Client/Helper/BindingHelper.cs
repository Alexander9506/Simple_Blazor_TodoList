using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simple_Blazor_Todo.Client.Helper
{
    public class BindingHelper
    {
        public static void ChangeAttribute<T>(ChangeEventArgs e, Expression<Func<T>> property, Object o, Action<string> OnPropertyChanged = null)
        {
            MemberExpression memberExpression = property.Body as MemberExpression;
            if (memberExpression != null)
            {
                System.Reflection.PropertyInfo propertyInfo = memberExpression.Member as System.Reflection.PropertyInfo;
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(o, Convert<T>(e.Value));
                    OnPropertyChanged?.Invoke(propertyInfo.Name);
                }
            }
        }

        private static T Convert<T>(Object value)
        {
            if (value != null)
            {
                if (value.GetType().FullName == typeof(T).FullName)
                {
                    return (T)value;
                }

                try
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter != null)
                    {
                        return (T)converter.ConvertFrom(value);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Cannot convert from {value.GetType().FullName} to {typeof(T).FullName }");
                    Console.WriteLine(e.Message);
                }
            }
            return default;
        }
    }
}
