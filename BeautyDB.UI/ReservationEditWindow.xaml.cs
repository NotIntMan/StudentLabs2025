namespace BeautyDB.UI;

using System.Collections.ObjectModel;
using System.Windows;
using BeautyDB.Domain;
using BeautyDB.UI.Converters;

public partial class ReservationEditWindow : Window
{
    private Reservation _reservation;

    public static ObservableCollection<Master> AvailableMasters { get; set; } = new()
    {
        new Master { Id = Guid.NewGuid(), Name = "Анна Иванова" },
        new Master { Id = Guid.NewGuid(), Name = "Мария Петрова" },
        new Master { Id = Guid.NewGuid(), Name = "Елена Сидорова" }
    };

    public static ReservationStatus[] AvailableStatuses { get; } = Enum.GetValues<ReservationStatus>();

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

        if (string.IsNullOrWhiteSpace(_reservation.Client.Name))
        {
            validationError = "Укажите имя клиента";
            return false;
        }

        if (string.IsNullOrWhiteSpace(_reservation.Client.Phone))
        {
            validationError = "Укажите телефон клиента";
            return false;
        }

        if (_reservation.Master is null)
        {
            validationError = "Выберите мастера";
            return false;
        }

        if (string.IsNullOrWhiteSpace(_reservation.ServiceDescription))
        {
            validationError = "Укажите описание услуги";
            return false;
        }

        if (!TimeOnlyConverter.TryParse(StartTimeTextBox.Text, out _))
        {
            validationError = "Неверный формат времени. Используйте формат ЧЧ:ММ (например, 14:30).";
            return false;
        }

        if (!TimeSpan.TryParse(DurationTextBox.Text, out var duration) || duration.TotalMinutes <= 0)
        {
            validationError = "Неверный формат длительности. Используйте формат ЧЧ:ММ (например, 00:30).";
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