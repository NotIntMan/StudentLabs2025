namespace BeautyDB.UI;

using System.Windows;
using BeautyDB.Data.Interfaces;

public partial class ReservationsListWindow : Window
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMasterRepository _masterRepository;
    private readonly ReservationsListWindowState _state = new();

    public ReservationsListWindow(IReservationRepository reservationRepository, IMasterRepository masterRepository)
    {
        InitializeComponent();
        _reservationRepository = reservationRepository;
        _masterRepository = masterRepository;
        DataContext = _state;
        LoadReservations();
    }

    private void LoadReservations()
    {
        var reservations = _reservationRepository.GetAll();
        _state.UpdateReservations(reservations);
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        var reservation = ReservationEditWindow.Create(_masterRepository);
        if (reservation != null)
        {
            _reservationRepository.Add(reservation);
            LoadReservations();
        }
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedReservation = _state.SelectedReservation;
        if (selectedReservation is not null)
        {
            var editedReservation = ReservationEditWindow.Edit(selectedReservation, _masterRepository);
            if (editedReservation != null)
            {
                _reservationRepository.Update(editedReservation);
                LoadReservations();
            }
        }
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedReservation = _state.SelectedReservation;
        if (selectedReservation is not null)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить эту запись?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _reservationRepository.Delete(selectedReservation);
                LoadReservations();
            }
        }
    }
}