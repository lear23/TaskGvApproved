

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using AllForApproved.Contexts;

namespace AllForApproved.Factories;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\SkolaUppgifter\AllForApproved\AllForApproved\Data\DataBaseCF.mdf;Integrated Security=True;Connect Timeout=30");

        return new DataContext(optionsBuilder.Options);
    }  
}