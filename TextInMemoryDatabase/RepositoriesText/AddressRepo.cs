

using AllForApproved.Entities;
using TextInMemoryDatabase.ContextsText;

namespace TextInMemoryDatabase.RepositoriesText;

public class AddressRepo
{
    private readonly DataContextsText _dataContexts;

    public AddressRepo(DataContextsText dataContexts)
    {
        _dataContexts = dataContexts;
    }

    public AddressEntity Create(AddressEntity entity)
    {
        _dataContexts.Address.Add(entity);
        _dataContexts.SaveChanges();
        return entity;
    }

    public IEnumerable<AddressEntity> Get()
    {
        return _dataContexts.Address.ToList();
    }

}
