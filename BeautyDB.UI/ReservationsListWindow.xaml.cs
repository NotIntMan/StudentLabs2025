namespace BeautyDB.UI;

using System.Collections.ObjectModel;
using System.Windows;
using BeautyDB.Data.Interfaces;
using BeautyDB.Domain;

public partial class ReservationsListWindow : Window
{
    private readonly IReservationRepository _repository;

    public ObservableCollection<Reservation> Reservations { get; set; } = new();

    public Reservation? SelectedReservation { get; set; }

    public ReservationsListWindow(IReservationRepository repository)
    {
        InitializeComponent();
        _repository = repository;
        DataContext = this;
        LoadReservations();
    }

    private void LoadReservations()
    {
        var reservations = _repository.GetAll();
        Reservations.Clear();
        foreach (var reservation in reservations)
        {
            Reservations.Add(reservation);
        }
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
        var selectedReservation = SelectedReservation;
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
        var selectedReservation = SelectedReservation;
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