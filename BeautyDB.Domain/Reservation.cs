namespace BeautyDB.Domain;

public class Reservation
{
    public required Guid Id { get; set; }
    public required Client Client { get; set; }
    public required Master? Master { get; set; }
    public required string ServiceDescription { get; set; }
    public required DateTime StartTime { get; set; }
    public required TimeSpan Duration { get; set; }
    public required ReservationStatus Status { get; set; }

    public static Reservation Create()
    {
        return new Reservation
        {
            Id = Guid.NewGuid(),
            Client = new Client { Name = "", Phone = "" },
            Master = null,
            ServiceDescription = "",
            StartTime = DateTime.Now,
            Duration = TimeSpan.FromMinutes(30),
            Status = ReservationStatus.Created
        };
    }

    public Reservation Clone()
    {
        return new Reservation
        {
            Id = Id,
            Client = new Client
            {
                Name = Client.Name,
                Phone = Client.Phone
            },
            Master = Master,
            ServiceDescription = ServiceDescription,
            StartTime = StartTime,
            Duration = Duration,
            Status = Status
        };
    }
}