﻿

using System.ComponentModel.DataAnnotations;

namespace AllForApproved.EntitiesTest;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }
    
    public string StreetAddress { get; set; } = null!;
    public string PostalCode { get; set; } = null!;

   
}
