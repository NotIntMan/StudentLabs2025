namespace BeautyDB.UI.Converters;

using System.Globalization;
using System.Windows;
using System.Windows.Data;
using BeautyDB.Domain;

public class ReservationStatusConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ReservationStatus status)
        {
            return status switch
            {
                ReservationStatus.Created => "Создана",
                ReservationStatus.Confirmed => "Подтверждена",
                ReservationStatus.InProgress => "В процессе",
                ReservationStatus.Cancelled => "Отменена",
                ReservationStatus.Done => "Завершена",
                _ => status.ToString()
            };
        }

        return DependencyProperty.UnsetValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}