using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SimpleBookCatalogWithControllers.Client.ClientServices;
using SimpleBookCatalogWithControllers.Shared.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add services to the container.
builder.Services.AddScoped<IBookService, BookService>();

// Add HttpClient
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();
