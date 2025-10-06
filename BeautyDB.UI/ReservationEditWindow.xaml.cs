namespace BeautyDB.UI;

using System.Windows;
using BeautyDB.Domain;

public partial class ReservationEditWindow : Window
{
    private Reservation _reservation;

    private ReservationEditWindow(Reservation? reservation)
    {
        _reservation = reservation is null
            ? Reservation.Create()
            : reservation.Clone();
        InitializeComponent();
        DataContext = _reservation;
    }

    public static Reservation? Create()
    {
        var window = new ReservationEditWindow(null);
        window.Title = "Создание резервации";

        return window.ShowDialog() == true ? window._reservation : null;
    }

    public static Reservation? Edit(Reservation reservation)
    {
        var window = new ReservationEditWindow(reservation);
        window.Title = "Редактирование резервации";

        return window.ShowDialog() == true ? window._reservation : null;
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Implement save logic
        DialogResult = true;
        Close();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}