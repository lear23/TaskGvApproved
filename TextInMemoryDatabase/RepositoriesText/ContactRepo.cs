

using AllForApproved.Entities;
using TextInMemoryDatabase.ContextsText;

namespace TextInMemoryDatabase.RepositoriesText;

public class ContactRepo
{
    private readonly DataContextsText _dataContexts;

    public ContactRepo(DataContextsText dataContexts)
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
