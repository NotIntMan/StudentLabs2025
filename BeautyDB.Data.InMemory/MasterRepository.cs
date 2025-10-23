namespace BeautyDB.Data.InMemory;

using BeautyDB.Data.Interfaces;
using BeautyDB.Domain;

public class MasterRepository : IMasterRepository
{
    private readonly List<Master> _masters = new();

    public List<Master> GetAll()
    {
        return _masters;
    }

    public Master? Get(Guid id)
    {
        return _masters.FirstOrDefault(m => m.Id == id);
    }

    public Guid Add(Master master)
    {
        var newMaster = new Master
        {
            Id = Guid.NewGuid(),
            Name = master.Name
        };
        _masters.Add(newMaster);
        return newMaster.Id;
    }
}