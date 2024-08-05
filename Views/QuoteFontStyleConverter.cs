using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TakeHomeAssessment
{
    public class QuoteFontStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string quote)
            {
                var length = quote.Length;

                if (length % 3 == 0)
                {
                    return FontAttributes.Bold;
                }
                if (length >= 80)
                {
                    return FontAttributes.Italic;
                }
                if (length >= 50)
                {
                    return FontAttributes.None; // Underline is not directly supported; use a separate property for styling
                }
                return FontAttributes.None;
            }
            return FontAttributes.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
