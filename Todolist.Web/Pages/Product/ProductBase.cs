using Microsoft.AspNetCore.Components;
using Todolist.Web.Services.IServices.IProduct;
using Todolist.Web.Services.Product;
using TodoList.Models.Dto.Product;

namespace Todolist.Web.Pages.Product
{
	public class ProductBase : ComponentBase
	{
		[Parameter]
        public int Ids { get; set; }

        [Parameter]
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public int ProductCategory { get; set; }
		public int ProductCount { get; set; }
		public int Price { get; set; }
		public int Qty { get; set; }
		public string Image { get; set; }

		[Inject]
		public IProductServices ProductServices { get; set; }

		public IEnumerable<ProductDto> Products { get; set;}
		public IEnumerable<ProductUpdateToDto> ProductsId { get; set;}

		public IEnumerable<CategoriDto> Categori { get; set;}

		public IEnumerable<ProductAddToDto> ProductsAddTo { get; set; }


		private List<ProductAddToDto> AddProduct = new();

        protected override async Task OnInitializedAsync()
        {
            //return base.OnInitializedAsync();
            Products = await ProductServices.GetAllProducts();
            Categori = await ProductServices.GetAllCategori();
        }

        protected async Task AddProduct_Click(ProductAddToDto ProductsAddTo)
        {
			try
			{
				var product = await ProductServices.AddProduct(ProductsAddTo);
			}
			catch (Exception)
			{
				//throw;
			}
        }
		protected async Task DelProduct_Click(int Id)
        {
			try
			{
				var product = await ProductServices.DeleteProduct(Id);
			}
			catch (Exception)
			{
				//throw;
			}
        }
    }
}
