using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Api.Models.Product;
using TodoList.Api.Repository.IRepositories.IProductRepositori;
using TodoList.Models.Dto.Product;

namespace TodoList.Api.Repository.ProductRepositori
{
	public class ProductRepository : IProductRepository
	{
		private readonly DataContext dataContext;

		public ProductRepository(DataContext dataContext)
		{
			this.dataContext = dataContext;
		}
		public async Task<Product> AddProduct(ProductAddToDto productAddToDto)
		{
			//throw new NotImplementedException();
			var item = new Product
			{
				Name = productAddToDto.Name,
				CategoryId= productAddToDto.CategoryId,
				Description= productAddToDto.Description,
				ImageURL= productAddToDto.ImageURL,
				Price= productAddToDto.Price,
				Qty= productAddToDto.Qty
			};
			var result = await this.dataContext.Product.AddAsync(item);
			await this.dataContext.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<Product> DelateProduct(int id)
		{
			//throw new NotImplementedException();
			var item = await this.dataContext.Product.FindAsync(id);
			if (item != null)
			{
				this.dataContext.Product.Remove(item);
				await this.dataContext.SaveChangesAsync();
			}
			return item;
		}

		public async Task<Product> EditProduct(int id, ProductUpdateToDto productUpdateToDto)
		{
			//throw new NotImplementedException();
			var item = await this.dataContext.Product.FindAsync(id);

			if (item != null)
			{
				item.Name = productUpdateToDto.Name;
				item.ImageURL = productUpdateToDto.ImageURL;
				item.Price = productUpdateToDto.Price;
				item.Qty = productUpdateToDto.Qty;
				item.CategoryId = productUpdateToDto.CategoryId;
				item.Description = productUpdateToDto.Description;
				await this.dataContext.SaveChangesAsync();
				return item;
			}
			return null;
		}

		

		public async Task<IEnumerable<Product>> GetAllProduct()
		{
			var product = await this.dataContext.Product.ToListAsync();
			return product;
		}

		public async Task<IEnumerable<ProductCategory>> GetAllProductCategoty()
		{
			//throw new NotImplementedException();
			var category = await this.dataContext.ProductCategory.ToListAsync();
			return category;
		}


		async Task<Product> IProductRepository.GetProductId(int id)
		{
			//throw new NotImplementedException();
			return await(from products in this.dataContext.Product
						 where products.Id == id
						 select new Product
						 {
							 Name = products.Name,
							 ImageURL = products.ImageURL,
							 Price = products.Price,
							 Qty = products.Qty,
							 CategoryId = products.CategoryId,
							 Description = products.Description,
						 }).SingleOrDefaultAsync();
		}

		/*public async Task<Product> GetProductCategoryId(int id)
		{
			//throw new NotImplementedException();
			return await(from product in this.dataContext.Product
						 join productCategory in this.dataContext.ProductCategory
						 on product.CategoryId equals productCategory.Id
						 where product.CategoryId == id
						 select new Product
						 {
							CategoryId= productCategory.Id,
							Name= productCategory.Name
						 }).SingleOrDefaultAsync();
		}*/
	}
}
