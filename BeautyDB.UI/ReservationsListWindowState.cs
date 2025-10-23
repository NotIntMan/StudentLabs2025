namespace BeautyDB.UI;

using System.Collections.ObjectModel;
using BeautyDB.Domain;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class ReservationsListWindowState : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Reservation> _reservations = new();
    [ObservableProperty] private Reservation? _selectedReservation;

    public void UpdateReservations(IEnumerable<Reservation> reservations)
    {
        Reservations = new ObservableCollection<Reservation>(reservations);
    }
}