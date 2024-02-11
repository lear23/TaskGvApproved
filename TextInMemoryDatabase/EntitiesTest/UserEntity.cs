

using System.ComponentModel.DataAnnotations;

namespace AllForApproved.EntitiesTest;

public class UserEntity
{
    [Key]
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
}

