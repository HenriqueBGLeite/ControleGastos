using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.Pages.Converters
{
    public class IntToMonthConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || (int)value == 0) 
                return null;

            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)value);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return Array.IndexOf(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames, value) + 1;
        }
    }
}
