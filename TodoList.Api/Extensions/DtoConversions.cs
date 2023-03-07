using TodoList.Api.Models.Product;
using TodoList.Models.Dto.Product;

namespace TodoList.Api.Extensions
{
	public static class DtoConversions
	{
		/*public static IEnumerable<ProductAddToDto> ProductConvert(this IEnumerable<Product> product, IEnumerable<ProductCategory> productCategory)
		{
			return (from products in product
					join productCategori in productCategory
					on products.CategoryId equals productCategori.Id
					select new ProductAddToDto
					{
						CategoryId = products.CategoryId,
						Qty= products.Qty,
						Price= products.Price,
						ImageURL= products.ImageURL,
						Name= products.Name,
						Description= products.Description
					}
					).ToList();
		}*/
		public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products, IEnumerable<ProductCategory> productCategories)
		{
			return (from product in products
					join ProductCategory in productCategories
					on product.CategoryId equals ProductCategory.Id
					select new ProductDto
					{
						Id = product.Id,
						Name = product.Name,
						Description = product.Description,
						ImageURL = product.ImageURL,
						Price = product.Price,
						Qty = product.Qty,
						CategoryName = ProductCategory.Name
					}
					).ToList();
		}
	}
}
