
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextInMemoryDatabase.ContextsText;
using TextInMemoryDatabase.RepositoriesText;
using TextsConsoleApp.Services;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddDbContext<DataContextsText>(x => x.UseInMemoryDatabase($"{Guid.NewGuid()}"));


    services.AddScoped<AddressRepo>();
    services.AddSingleton<MainProgramText>();

}).Build();


var mainProgramText = builder.Services.GetRequiredService<MainProgramText>();

Console.Clear();

mainProgramText.CreateAdress();

  
