namespace BeautyDB.Data.Interfaces;

using BeautyDB.Domain;

public interface IMasterRepository
{
    List<Master> GetAll();
    Master? Get(Guid id);
    Guid Add(Master master);
}