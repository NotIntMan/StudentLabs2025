namespace BeautyDB.UI;

using System.Collections.ObjectModel;
using BeautyDB.Domain;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class ReservationEditWindowState : ObservableObject
{
    [ObservableProperty] private Reservation _reservation = Reservation.Create();
    [ObservableProperty] private ObservableCollection<Master> _availableMasters = new();

    public ReservationStatus[] AvailableStatuses { get; } = Enum.GetValues<ReservationStatus>();

    public void UpdateAvailableMasters(IEnumerable<Master> masters)
    {
        AvailableMasters = new ObservableCollection<Master>(masters);
    }
}