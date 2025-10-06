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
    private IMasterRepository _masterRepository = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _reservationRepository = new ReservationRepository();
        _masterRepository = new MasterRepository();

        var mainWindow = new ReservationsListWindow(_reservationRepository, _masterRepository);
        mainWindow.Show();
    }
}