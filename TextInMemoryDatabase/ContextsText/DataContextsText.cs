


using AllForApproved.Entities;
using Microsoft.EntityFrameworkCore;

namespace TextInMemoryDatabase.ContextsText;

public class DataContextsText :DbContext
{

    public DataContextsText()
    {

    }

    public DataContextsText(DbContextOptions<DataContextsText> options) : base(options) 
    {
        
    }    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase($"{Guid.NewGuid()}");
    }

    public DbSet<AddressEntity> Address { get; set; }
    public DbSet<ContactEntity> Contact { get; set; }
    public DbSet<CountryEntity> Country { get; set; }
    public DbSet<CustomerEntity> Customer { get; set; }
    public DbSet<UserEntity> User { get; set; }
}
