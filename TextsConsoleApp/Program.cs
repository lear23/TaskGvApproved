
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextInMemoryDatabase.ContextsText;
using TextInMemoryDatabase.RepositoriesText;
using TextInMemoryDatabase.ServicesText;
using TextsConsoleApp.Services;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddDbContext<DataContextsText>(x => x.UseInMemoryDatabase($"{Guid.NewGuid()}"));


    services.AddScoped<AddressRepo>();
    services.AddScoped<CustomerServiceText>();

    services.AddSingleton<MainProgramText>();
    services.AddSingleton<MainCustomerService>();

}).Build();


var mainProgramText = builder.Services.GetRequiredService<MainProgramText>();
var mainCustomerText = builder.Services.GetRequiredService<MainCustomerService>();

Console.Clear();

//mainProgramText.CreateAdress();
//mainProgramText.ListAllAddresser(); 

mainCustomerText.CreateCustomer();
mainCustomerText.ListAllCustomers();

