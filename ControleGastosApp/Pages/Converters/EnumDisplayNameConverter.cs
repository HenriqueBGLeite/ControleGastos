using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.Pages.Converters
{
    public class EnumDisplayNameConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) 
                return string.Empty;

            var field = value.GetType().GetField(value.ToString()!);

            var displayAttribute = field?.GetCustomAttributes(typeof(DisplayAttribute), false)
                                        .Cast<DisplayAttribute>()
                                        .FirstOrDefault();

            return displayAttribute?.Name ?? value.ToString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
