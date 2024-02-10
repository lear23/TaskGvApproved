


using AllForApproved.Contexts;
using AllForApproved.ProductRepo;
using AllForApproved.ProductServices;
using AllForApproved.Repositories;
using AllForApproved.Services;
using ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;



var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lears\source\repos\lear23\TaskGvApproved\AllForApproved\Data\DataBaseCF.mdf;Integrated Security=True"));
    services.AddDbContext<ProductCatalog>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lears\source\repos\lear23\TaskGvApproved\AllForApproved\Data\ProductDataBase.mdf;Integrated Security=True"));
   
    services.AddScoped<AddressRepo>();
    services.AddScoped<ContactRepo>();
    services.AddScoped<CustomerRepo>();
    services.AddScoped<CountryRepo>();
    services.AddScoped<UserRepo>();

    services.AddScoped<CategoryRepo>();
    services.AddScoped<ClientsRepo>();
    services.AddScoped<DirectionRepo>();
    services.AddScoped<ProductsRepo>();
    services.AddScoped<ReadersRepo>();


    services.AddScoped<AddressService>();
    services.AddScoped<ContactService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<CountryService>();
    services.AddScoped<UserService>();

    services.AddScoped<CategoryService>();
    services.AddScoped<ClientService>();
    services.AddScoped<DirectionService>();
    services.AddScoped<ProductServices>();
    services.AddScoped<ReadersServices>();




    services.AddSingleton<MenuService>();
    services.AddSingleton<ProductCatalogService>();



}).Build();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.CreateCustomer_UI();
menuService.GetCustomer_UI();
menuService.DeleteCustomer();

//var productService = builder.Services.GetRequiredService<ProductCatalogService>();
//productService.CreateProduct_UI();
//productService.GetProduct_UI();
//productService.DeleteProductById_UI();


