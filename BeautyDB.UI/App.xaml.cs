using System.Windows;
using BeautyDB.Data.InMemory;
using BeautyDB.Data.Interfaces;

namespace BeautyDB.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IReservationRepository _reservationRepository = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _reservationRepository = new ReservationRepository();

        var mainWindow = new ReservationsListWindow(_reservationRepository);
        mainWindow.Show();
    }
}