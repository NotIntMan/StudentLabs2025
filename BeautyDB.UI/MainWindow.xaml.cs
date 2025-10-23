using System.Windows;
using BeautyDB.Domain;

namespace BeautyDB.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Reservation? _currentReservation;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        var reservation = ReservationEditWindow.Create();
        if (reservation is not null)
        {
            _currentReservation = reservation;
            DisplayReservation();
        }
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (_currentReservation is null)
        {
            MessageBox.Show("Сначала создайте резервацию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var edited = ReservationEditWindow.Edit(_currentReservation);
        if (edited is not null)
        {
            _currentReservation = edited;
            DisplayReservation();
        }
    }

    private void DisplayReservation()
    {
        if (_currentReservation is null)
        {
            ReservationTextBlock.Text = "";
            return;
        }

        ReservationTextBlock.Text = $"""
            Резервация #{_currentReservation.Id}

            Клиент: {_currentReservation.Client.Name}
            Телефон: {_currentReservation.Client.Phone}
            Мастер: {_currentReservation.Master?.Name ?? "Не выбран"}
            Услуга: {_currentReservation.ServiceDescription}
            Дата: {_currentReservation.Date:dd.MM.yyyy}
            Время: {_currentReservation.StartTime:HH:mm}
            Длительность: {_currentReservation.Duration.TotalMinutes} мин
            Статус: {_currentReservation.Status}
            """;
    }
}