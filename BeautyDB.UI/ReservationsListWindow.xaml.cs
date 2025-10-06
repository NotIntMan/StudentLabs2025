namespace BeautyDB.UI;

using System.Windows;
using BeautyDB.Data.Interfaces;

public partial class ReservationsListWindow : Window
{
    private readonly IReservationRepository _repository;
    private readonly ReservationsListWindowState _state = new();

    public ReservationsListWindow(IReservationRepository repository)
    {
        InitializeComponent();
        _repository = repository;
        DataContext = _state;
        LoadReservations();
    }

    private void LoadReservations()
    {
        var reservations = _repository.GetAll();
        _state.UpdateReservations(reservations);
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        var reservation = ReservationEditWindow.Create();
        if (reservation != null)
        {
            _repository.Add(reservation);
            LoadReservations();
        }
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedReservation = _state.SelectedReservation;
        if (selectedReservation is not null)
        {
            var editedReservation = ReservationEditWindow.Edit(selectedReservation);
            if (editedReservation != null)
            {
                _repository.Update(editedReservation);
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
                _repository.Delete(selectedReservation);
                LoadReservations();
            }
        }
    }
}