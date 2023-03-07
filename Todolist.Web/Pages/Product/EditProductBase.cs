using Microsoft.AspNetCore.Components;
using Todolist.Web.Services.IServices.IProduct;
using TodoList.Models.Dto.Product;

namespace Todolist.Web.Pages.Product
{
    public class EditProductBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

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

        public IEnumerable<ProductDto> ProductDetail { get; set; }

        public IEnumerable<CategoriDto> Categori { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //return base.OnInitializedAsync();
            ProductDetail = await ProductServices.GetAllProducts();
            Categori = await ProductServices.GetAllCategori();
        }

        protected async Task EditProduct_Click(ProductUpdateToDto productUpdateToDto)
        {
            try
            {
                var product = await ProductServices.UpdateProduct(Id, productUpdateToDto);
            }
            catch (Exception)
            {
                //throw;
            }
        }

    }
}
