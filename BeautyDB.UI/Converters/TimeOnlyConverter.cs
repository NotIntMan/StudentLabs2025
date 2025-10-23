namespace BeautyDB.UI.Converters;

using System.Globalization;
using System.Windows;
using System.Windows.Data;

public class TimeOnlyConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is TimeOnly timeOnly)
        {
            return timeOnly.ToString("HH:mm", CultureInfo.CurrentCulture);
        }

        return DependencyProperty.UnsetValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string text && TryParse(text, out var timeOnly))
        {
            return timeOnly;
        }

        return DependencyProperty.UnsetValue;
    }

    public static bool TryParse(string text, out TimeOnly timeOnly)
    {
        return TimeOnly.TryParseExact(text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeOnly);
    }
}