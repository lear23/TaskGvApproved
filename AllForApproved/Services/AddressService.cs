

using AllForApproved.Entities;
using AllForApproved.ProductEntities;
using AllForApproved.ProductRepo;
using AllForApproved.Repositories;

namespace AllForApproved.Services;

public class AddressService
{
    private readonly AddressRepo _addressRepo;

    public AddressService(AddressRepo addressRepo)
    {
        _addressRepo = addressRepo;
    }

    public AddressEntity CreateAddress(string streetName, string postalCode)
    {
        var addressEntity = _addressRepo.Get(x => x.StreetAddress == streetName && x.PostalCode == postalCode);
        if (addressEntity == null)
        {
            addressEntity = _addressRepo.Create(new AddressEntity { StreetAddress = streetName, PostalCode = postalCode} );
           
        }
        return addressEntity;

    }

    public AddressEntity GetAddressId(int id)
    {
        var addressEntity = _addressRepo.Get(x => x.Id == id);
        return addressEntity;
    }

    public IEnumerable<AddressEntity>  GetAllAddress()
    {
        var addresses = _addressRepo.GetAll();
        return addresses;
    }

    //public AddressEntity UpdateAddress(AddressEntity addressEntity)
    //{
    //    if (addressEntity == null)
    //    {
    //        throw new ArgumentNullException(nameof(addressEntity), "The category entity cannot be null.");
    //    }

    //    // Call the Update method of the generic repository with the category entity

    //    var updatedCategory = _addressRepo.Update(addressEntity);

    //    return updatedCategory;
    //}

    public AddressEntity UpdateAddress(AddressEntity addressEntity)
    {
        var UpdateAddress = _addressRepo.Update(x => x.Id == addressEntity.Id, addressEntity);
        return UpdateAddress;
    }


    public void DeleteAddress(int id)
    {
        _addressRepo.Delete(x => x.Id == id);
    }

}


//public AddressEntity GetAddressId(string streetName, string postalCode)
//{
//    var addressEntity = _addressRepo.Get(x => x.StreetAddress == streetName && x.PostalCode == postalCode);
//    return addressEntity;
//}