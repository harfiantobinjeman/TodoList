using Microsoft.EntityFrameworkCore;
using TodoList.Api.Models.Product;

namespace TodoList.Api.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<Product> Product { get; set; }

		public DbSet<ProductCategory> ProductCategory { get; set; }

	}
}
