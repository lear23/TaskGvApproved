

using AllForApproved.Entities;
using Microsoft.EntityFrameworkCore;

namespace AllForApproved.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<CountryEntity> Countries { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<UserEntity> Users { get; set; }



}
