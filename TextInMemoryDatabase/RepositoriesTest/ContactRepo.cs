

using AllForApproved.EntitiesTest;
using TestInMemoryDatabase.ContextsTest;


namespace TextInMemoryDatabase.RepositoriesText;

public class ContactRepo
{
    private readonly DataContextsTest _dataContexts;

    public ContactRepo(DataContextsTest dataContexts)
    {
        _dataContexts = dataContexts;
    }

    public ContactEntity Create(ContactEntity entity)
    {
        _dataContexts.Contact.Add(entity);
        _dataContexts.SaveChanges();
        return entity;
    }

    public IEnumerable<ContactEntity> Get(ContactEntity entity)
    {
        return _dataContexts.Contact.ToList();
    }
}
