using TodoList.Api.Models.Product;
using TodoList.Models.Dto.Product;

namespace TodoList.Api.Repository.IRepositories.IProductRepositori
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(ProductAddToDto productAddToDto);
        Task<Product> DelateProduct(int id);
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductId(int id);
		Task<IEnumerable<ProductCategory>> GetAllProductCategoty();
        Task<Product> EditProduct(int id, ProductUpdateToDto productUpdateToDto);


	}
}
