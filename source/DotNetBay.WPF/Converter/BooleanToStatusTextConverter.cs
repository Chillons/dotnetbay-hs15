using System;
using System.Globalization;
using System.Windows.Data;

namespace DotNetBay.WPF.Converter
{
    public class BooleanToStatusTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Valid" : "Closed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
