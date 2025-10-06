namespace BeautyDB.UI.Converters;

using System.Globalization;
using System.Windows;
using System.Windows.Data;

public class DateOnlyConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is DateOnly dateOnly)
        {
            switch (parameter as string)
            {
                case "DateTime": return dateOnly.ToDateTime(TimeOnly.MinValue);
            }

            return dateOnly.ToString("dd.MM.yyyy", culture);
        }

        return DependencyProperty.UnsetValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (
            value is string stringValue
            && TryParse(stringValue, out var dateOnly)
        )
        {
            return dateOnly;
        }

        if (value is DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }

        return DependencyProperty.UnsetValue;
    }

    public static bool TryParse(string text, out DateOnly dateOnly)
    {
        return DateOnly.TryParseExact(text, "dd.MM.yyyy", out dateOnly);
    }
}