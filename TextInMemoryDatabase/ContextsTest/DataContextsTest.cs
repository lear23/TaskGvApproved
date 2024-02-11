


using AllForApproved.EntitiesTest;
using Microsoft.EntityFrameworkCore;

namespace TestInMemoryDatabase.ContextsTest;

public class DataContextsTest :DbContext
{

    public DataContextsTest()
    {

    }

    public DataContextsTest(DbContextOptions<DataContextsTest> options) : base(options) 
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
