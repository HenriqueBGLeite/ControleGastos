using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.Pages.Converters
{
    public class OperationTypeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) 
                return string.Empty;

            var enumType = value.GetType();
            var memberInfo = enumType.GetMember(value.ToString());

            if (memberInfo.Length > 0)
            {
                var displayAttr = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
                if (displayAttr != null)
                    return displayAttr.Name;
            }

            return value.ToString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
