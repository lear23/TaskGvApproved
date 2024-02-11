

using AllForApproved.EntitiesTest;
using TestInMemoryDatabase.ContextsTest;


namespace TextInMemoryDatabase.RepositoriesText;

public class AddressRepo
{
    private readonly DataContextsTest _dataContexts;

    public AddressRepo(DataContextsTest dataContexts)
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
