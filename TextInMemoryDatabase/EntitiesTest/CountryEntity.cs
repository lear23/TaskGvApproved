

using System.ComponentModel.DataAnnotations;

namespace AllForApproved.EntitiesTest;

public class CountryEntity
{
    [Key]
    public int Id { get; set; }
    
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;

  
}

