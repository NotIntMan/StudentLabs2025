namespace BeautyDB.UI;

using System.Windows;
using BeautyDB.Data.Interfaces;
using BeautyDB.Domain;
using BeautyDB.UI.Converters;

public partial class ReservationEditWindow : Window
{
    private readonly IMasterRepository _masterRepository;
    private readonly ReservationEditWindowState _state = new();

    private ReservationEditWindow(Reservation? reservation, IMasterRepository masterRepository)
    {
        _masterRepository = masterRepository;

        InitializeComponent();
        DataContext = _state;

        InitForm(reservation);
    }

    public static Reservation? Create(IMasterRepository masterRepository)
    {
        var window = new ReservationEditWindow(null, masterRepository);
        window.Title = "Создание резервации";

        return window.ShowDialog() == true ? window._state.Reservation : null;
    }

    public static Reservation? Edit(Reservation reservation, IMasterRepository masterRepository)
    {
        var window = new ReservationEditWindow(reservation, masterRepository);
        window.Title = "Редактирование резервации";

        return window.ShowDialog() == true ? window._state.Reservation : null;
    }

    private void InitForm(Reservation? reservation)
    {
        if (reservation is not null)
        {
            _state.Reservation = reservation.Clone();
        }

        var allMasters = _masterRepository.GetAll();
        _state.UpdateAvailableMasters(allMasters);
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (!ValidateForm(out var validationError))
        {
            MessageBox.Show(validationError, "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        DialogResult = true;
        Close();
    }

    private bool ValidateForm(out string validationError)
    {
        validationError = string.Empty;

        var reservation = _state.Reservation;

        if (string.IsNullOrWhiteSpace(reservation.Client.Name))
        {
            validationError = "Укажите имя клиента";
            return false;
        }

        if (string.IsNullOrWhiteSpace(reservation.Client.Phone))
        {
            validationError = "Укажите телефон клиента";
            return false;
        }

        if (reservation.Master is null)
        {
            validationError = "Выберите мастера";
            return false;
        }

        if (string.IsNullOrWhiteSpace(reservation.ServiceDescription))
        {
            validationError = "Укажите описание услуги";
            return false;
        }

        if (!TimeOnlyConverter.TryParse(StartTimeTextBox.Text, out _))
        {
            validationError = "Неверный формат времени. Используйте формат ЧЧ:ММ (например, 14:30).";
            return false;
        }

        if (!TimeSpanConverter.TryParse(DurationTextBox.Text, out var duration) || duration.TotalMinutes <= 0)
        {
            validationError = "Неверный формат длительности. Используйте формат ЧЧ:ММ (например, 00:30) или минуты (например, 30).";
            return false;
        }

        return true;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}