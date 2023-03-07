using TodoList.Models.Dto.Product;

namespace Todolist.Web.Services.IServices.IProduct
{
	public interface IProductServices
	{
		Task<IEnumerable<ProductDto>> GetAllProducts();

		Task<IEnumerable<CategoriDto>> GetAllCategori();

		Task<ProductDto> GetProductId(int id);

		Task<ProductAddToDto> AddProduct(ProductAddToDto productAddToDto);

		Task<ProductDto> UpdateProduct(int id, ProductUpdateToDto productUpdateToDto);

		Task<ProductDto> DeleteProduct(int id);
	}
}
