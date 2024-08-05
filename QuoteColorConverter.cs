using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TakeHomeAssessment
{
    public class QuoteColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string quote)
            {
                var length = quote.Length;

                if (length % 3 == 0)
                {
                    return Colors.Green; // Always green if divisible by 3
                }
                if (length < 30)
                {
                    return Colors.Black;
                }
                if (length >= 30 && length <= 65)
                {
                    return Colors.Purple;
                }
                if (length > 65 && length < 100)
                {
                    return Colors.Red;
                }
                return Colors.Blue;
            }
            return Colors.Black; // Default color
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
