using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using TodoList.Api.Data;
using TodoList.Api.Repository.IRepositories.IProductRepositori;
using TodoList.Api.Repository.ProductRepositori;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add dbcontext
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(policy => policy.WithOrigins("http://localhost:7275", "https://localhost:7275")
.AllowAnyMethod().WithHeaders(HeaderNames.ContentType));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
