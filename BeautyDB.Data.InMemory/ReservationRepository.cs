namespace BeautyDB.Data.InMemory;

using BeautyDB.Data.Interfaces;
using BeautyDB.Domain;

public class ReservationRepository : IReservationRepository
{
    private readonly List<Reservation> _reservations = new();

    public List<Reservation> GetAll()
    {
        return _reservations.Select(r => r.Clone()).ToList();
    }

    public Guid Add(Reservation reservation)
    {
        var clone = reservation.Clone();
        clone.Id = Guid.NewGuid();
        _reservations.Add(clone);
        return clone.Id;
    }

    public void Update(Reservation reservation)
    {
        var index = _reservations.FindIndex(r => r.Id == reservation.Id);
        if (index >= 0)
        {
            _reservations[index] = reservation.Clone();
        }
    }

    public void Delete(Reservation reservation)
    {
        _reservations.RemoveAll(r => r.Id == reservation.Id);
    }
}