namespace BeautyDB.UI.Converters;

using System.Globalization;
using System.Windows;
using System.Windows.Data;

public class TimeSpanConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is TimeSpan timeSpan)
        {
            return $"{(int)timeSpan.TotalHours:D2}:{timeSpan.Minutes:D2}";
        }

        return DependencyProperty.UnsetValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string text && TryParse(text, out var timeSpan))
        {
            return timeSpan;
        }

        return DependencyProperty.UnsetValue;
    }

    public static bool TryParse(string text, out TimeSpan timeSpan)
    {
        if (TimeSpan.TryParseExact(text, @"hh\:mm", CultureInfo.InvariantCulture, out timeSpan))
        {
            return true;
        }

        if (TimeSpan.TryParseExact(text, @"h\:mm", CultureInfo.InvariantCulture, out timeSpan))
        {
            return true;
        }

        if (int.TryParse(text, out var minutes))
        {
            timeSpan = TimeSpan.FromMinutes(minutes);
            return true;
        }

        timeSpan = TimeSpan.Zero;
        return false;
    }
}