using System.Windows;
using BeautyDB.Data.InMemory;
using BeautyDB.Data.Interfaces;
using BeautyDB.Domain;

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

        SeedInitData();

        var mainWindow = new ReservationsListWindow(_reservationRepository, _masterRepository);
        mainWindow.Show();
    }

    private void SeedInitData()
    {
        var master0Id = _masterRepository.Add(new Master { Name = "Анна Иванова" });
        var master0 = _masterRepository.Get(master0Id)!;
        var master1Id = _masterRepository.Add(new Master { Name = "Мария Петрова" });
        var master1 = _masterRepository.Get(master1Id)!;
        var master2Id = _masterRepository.Add(new Master { Name = "Елена Сидорова" });
        var master2 = _masterRepository.Get(master2Id)!;

        var client0 = new Client { Name = "Смирнова О.В.", Phone = "+7 916 234-5678" };
        var client1 = new Client { Name = "Козлова Т.И.", Phone = "+7 925 876-5432" };
        var client2 = new Client { Name = "Новикова Е.С.", Phone = "+7 903 456-7890" };
        var client3 = new Client { Name = "Морозова Н.А.", Phone = "+7 926 123-4567" };
        var client4 = new Client { Name = "Волкова К.Д.", Phone = "+7 915 987-6543" };
        var client5 = new Client { Name = "Соколова М.П.", Phone = "+7 917 345-6789" };

        _reservationRepository.Add(new Reservation
        {
            Id = Guid.NewGuid(),
            Client = client0,
            Master = master0,
            ServiceDescription = "Стрижка и укладка",
            Date = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            StartTime = new TimeOnly(10, 0),
            Duration = TimeSpan.FromMinutes(60),
            Status = ReservationStatus.Created
        });

        _reservationRepository.Add(new Reservation
        {
            Id = Guid.NewGuid(),
            Client = client1,
            Master = master1,
            ServiceDescription = "Маникюр",
            Date = DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
            StartTime = new TimeOnly(14, 30),
            Duration = TimeSpan.FromMinutes(90),
            Status = ReservationStatus.Created
        });

        _reservationRepository.Add(new Reservation
        {
            Id = Guid.NewGuid(),
            Client = client2,
            Master = master2,
            ServiceDescription = "Окрашивание волос",
            Date = DateOnly.FromDateTime(DateTime.Today.AddDays(3)),
            StartTime = new TimeOnly(11, 0),
            Duration = TimeSpan.FromMinutes(120),
            Status = ReservationStatus.Created
        });

        _reservationRepository.Add(new Reservation
        {
            Id = Guid.NewGuid(),
            Client = client3,
            Master = master0,
            ServiceDescription = "Педикюр",
            Date = DateOnly.FromDateTime(DateTime.Today.AddDays(4)),
            StartTime = new TimeOnly(16, 0),
            Duration = TimeSpan.FromMinutes(75),
            Status = ReservationStatus.Created
        });

        _reservationRepository.Add(new Reservation
        {
            Id = Guid.NewGuid(),
            Client = client4,
            Master = master1,
            ServiceDescription = "Комплекс: маникюр + педикюр",
            Date = DateOnly.FromDateTime(DateTime.Today.AddDays(5)),
            StartTime = new TimeOnly(12, 30),
            Duration = TimeSpan.FromMinutes(150),
            Status = ReservationStatus.Created
        });

        _reservationRepository.Add(new Reservation
        {
            Id = Guid.NewGuid(),
            Client = client5,
            Master = master2,
            ServiceDescription = "Вечерняя укладка",
            Date = DateOnly.FromDateTime(DateTime.Today.AddDays(6)),
            StartTime = new TimeOnly(18, 0),
            Duration = TimeSpan.FromMinutes(45),
            Status = ReservationStatus.Created
        });
    }
}