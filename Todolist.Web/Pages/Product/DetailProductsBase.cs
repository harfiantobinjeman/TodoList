using Microsoft.AspNetCore.Components;
using Todolist.Web.Services.IServices.IProduct;
using Todolist.Web.Services.Product;
using TodoList.Models.Dto.Product;

namespace Todolist.Web.Pages.Product
{
    public class DetailProductsBase:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IProductServices ProductServices { get; set; }

        public IEnumerable<ProductDto> ProductDetail { get; set; }

        public IEnumerable<CategoriDto> CategoriDetail { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //return base.OnInitializedAsync();
            ProductDetail = await ProductServices.GetAllProducts();
            CategoriDetail = await ProductServices.GetAllCategori();
        }
    }
}
