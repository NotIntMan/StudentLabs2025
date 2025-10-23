namespace BeautyDB.Data.Interfaces;

using BeautyDB.Domain;

public interface IReservationRepository
{
    List<Reservation> GetAll();
    Guid Add(Reservation reservation);
    void Update(Reservation reservation);
    void Delete(Reservation reservation);
}