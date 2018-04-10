using System;
using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile.ValueConverters
{
    public class BooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is Boolean)) return value;
            return !((Boolean)value);
        }

        public object ConvertBack(object value, Type targetType, object parametr, System.Globalization.CultureInfo culture)
        {
            if (!(value is Boolean)) return value;
            return !((Boolean)value);
        }
    }
}
