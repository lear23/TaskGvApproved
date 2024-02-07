

using System.ComponentModel.DataAnnotations;

namespace AllForApproved.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }
    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public int ContactId { get; set; }
    public  ContactEntity Contact { get; set; } = null!;

    public int AddressId { get; set; }
    public  AddressEntity Address { get; set;} = null!;

    public int CountryId { get; set; }
    public  CountryEntity Country { get; set;} = null!;

  
}

