

using AllForApproved.Entities;
using AllForApproved.Repositories;
using System.Diagnostics.Metrics;

namespace AllForApproved.Services;

public class ContactService
{

    private readonly ContactRepo _contactRepo;
    private readonly UserService _userService;

    public ContactService(ContactRepo contactRepo, UserService userService)
    {
        _contactRepo = contactRepo;
        _userService = userService;
    }


    //public ContactEntity CreateContact(string email, string phoneNumber, string userName)
    //{
    //    var userEntity = _userService.CreateUser(userName);
    //    var contactEntity = _contactRepo.Get(x => x.Email == email && x.PhoneNumber == phoneNumber);
    //    if (contactEntity == null)
    //    {
    //        contactEntity = _contactRepo.Create(new ContactEntity { Email = email, PhoneNumber = phoneNumber });

    //    }
    //    return contactEntity;
    //}

    public ContactEntity CreateContact(string email, string phoneNumber, string userName)
    {
        var userEntity = _userService.CreateUser(userName);       
          var contactEntity = new ContactEntity 
          { 
              Email = email,        
              PhoneNumber = phoneNumber,
              UserId = userEntity.Id,
          };
        contactEntity = _contactRepo.Create(contactEntity);       
        return contactEntity;
    }

    public ContactEntity GetContactId(string email)
    {
        var contactEntity = _contactRepo.Get(x => x.Email == email);
        return contactEntity;
    }

    //public ContactEntity GetContactId(int id)
    //{
    //    var contactEntity = _contactRepo.Get(x => x.Id == id);
    //    return contactEntity;
    //}

    public IEnumerable<ContactEntity> GetAllCountry()
    {
        var contacts = _contactRepo.GetAll();
        return contacts;
    }

    public ContactEntity UpdateContact(ContactEntity contactEntity)
    {
        var UpdateContact = _contactRepo.Update(x => x.Id == contactEntity.Id, contactEntity);
        return UpdateContact;
    }


    public void DeleteContact(string email)
    {
        _contactRepo.Delete(x => x.Email == email);
    }

    //public void DeleteContact(int id)
    //{
    //    _contactRepo.Delete(x => x.Id == id);
    //}





}
