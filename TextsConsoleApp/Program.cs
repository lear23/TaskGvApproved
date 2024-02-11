
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestInMemoryDatabase.ContextsTest;

using TextInMemoryDatabase.RepositoriesText;
using TextInMemoryDatabase.ServicesText;
using TextsConsoleApp.Services;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddDbContext<DataContextsTest>(x => x.UseInMemoryDatabase($"{Guid.NewGuid()}"));


    services.AddScoped<AddressRepo>();
    services.AddScoped<CustomerServiceTest>();

    services.AddSingleton<MainProgramTest>();
    services.AddSingleton<MainCustomerService>();

}).Build();


var mainProgramTest = builder.Services.GetRequiredService<MainProgramTest>();
var mainCustomerTest = builder.Services.GetRequiredService<MainCustomerService>();

Console.Clear();

//mainProgramTest.CreateAdress();
//mainProgramTest.ListAllAddresser(); 

mainCustomerTest.CreateCustomer();
mainCustomerTest.ListAllCustomers();

