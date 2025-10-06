namespace BeautyDB.Domain;

public class Reservation
{
    public Guid Id { get; set; }
    public required Client Client { get; set; }
    public required Master Master { get; set; }
    public required string ServiceDescription { get; set; }
    public required DateTime StartTime { get; set; }
    public required TimeSpan Duration { get; set; }
    public required ReservationStatus Status { get; set; }
}