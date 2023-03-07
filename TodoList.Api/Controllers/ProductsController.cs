using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Extensions;
using TodoList.Api.Models.Product;
using TodoList.Api.Repository.IRepositories.IProductRepositori;
using TodoList.Models.Dto.Product;

namespace TodoList.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository productRepository;

		public ProductsController(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProduct()
		{
			try
			{
				var product = await this.productRepository.GetAllProduct();
				var categori = await this.productRepository.GetAllProductCategoty();

				if (product == null || categori == null)
				{
					return NotFound();
				}
				else
				{
					var productDto = product.ConvertToDto(categori);
					return Ok(productDto);
				}
			}
			catch (Exception)
			{

				//throw;
				return StatusCode(StatusCodes.Status500InternalServerError, "Erorr data from Database");
			}
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductId(int id)
		{
			var item = await this.productRepository.GetProductId(id);
			return Ok(item);
		}

        [HttpGet("Category")]
        public async Task<ActionResult<IEnumerable<CategoriDto>>> GetCategoriId()
        {
            var item = await this.productRepository.GetAllProductCategoty();
            return Ok(item);
        }

        [HttpPost]
		public async Task<ActionResult<ProductAddToDto>> AddProducts([FromBody] ProductAddToDto productAddToDto)
		{
			var newProduct = await this.productRepository.AddProduct(productAddToDto);
			return Ok(newProduct);
		}


		[HttpPatch("{id:int}")]
		public async Task <ActionResult<ProductUpdateToDto>> UpdateProduct(int id, ProductUpdateToDto productUpdateToDto)
		{
			var productUpdate = await this.productRepository.EditProduct(id, productUpdateToDto);
			return Ok(productUpdate);
		}


		[HttpDelete("{id:int}")]
		public async Task<ActionResult<ProductDto>> DeleteProduct(int id)
		{
			var item = await this.productRepository.DelateProduct(id);
			return Ok(item);
		}
	}
}
