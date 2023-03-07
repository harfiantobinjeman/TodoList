using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Todolist.Web;
using Todolist.Web.Services.IServices.IProduct;
using Todolist.Web.Services.Product;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7230/") });


builder.Services.AddScoped<IProductServices, ProductServices>();


await builder.Build().RunAsync();
