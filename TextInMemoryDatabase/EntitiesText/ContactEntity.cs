

using System.ComponentModel.DataAnnotations;

namespace AllForApproved.Entities;

public class ContactEntity 
{
    [Key]
    public int Id { get; set; }
  
    public string? PhoneNumber { get; set; }
    public string Email { get; set; } = null!;

    public int UserId { get; set; }
    public  UserEntity User { get; set; } = null!;
}

