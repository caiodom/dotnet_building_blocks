using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T> (this IEnumerable<T> items, Action<T> itemAction)
        {
            foreach(var item in items)
                itemAction(item);
        }

        public static string GetEnumDescripton<TEnum>(this TEnum item)
        {
            return item.GetType()
                       .GetField(item.ToString())
                       .GetCustomAttributes(typeof(DescriptionAttribute),false)
                       .Cast<DescriptionAttribute>()
                       .FirstOrDefault()?.Description ?? string.Empty;
        }
    }
}
