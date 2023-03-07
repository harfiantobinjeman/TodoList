using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using Todolist.Web.Services.IServices.IProduct;
using TodoList.Models.Dto.Product;

namespace Todolist.Web.Services.Product
{
	public class ProductServices : IProductServices
	{
		private readonly HttpClient httpClient;

		public ProductServices(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<ProductAddToDto>AddProduct(ProductAddToDto productAddToDto)
		{
			//throw new NotImplementedException();
			try
			{
				var response = await httpClient.PostAsJsonAsync<ProductAddToDto>("api/Products", productAddToDto);

				if (response.IsSuccessStatusCode)
				{
					if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
					{
						return default(ProductAddToDto);
					}
					return await response.Content.ReadFromJsonAsync<ProductAddToDto>();
				}
				else
				{
					var massege = await response.Content.ReadAsStringAsync();
					throw new Exception("Http Status :" + response.StatusCode + "-" + massege);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}


        public async Task<ProductDto> DeleteProduct(int id)
		{
            //throw new NotImplementedException();
            try
            {
                var response = await httpClient.DeleteAsync($"api/Products/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ProductDto>();
                }
                return default(ProductDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public async Task<IEnumerable<CategoriDto>> GetAllCategori()
        {
            //throw new NotImplementedException();
            try
            {
                var categori = await this.httpClient.GetFromJsonAsync<IEnumerable<CategoriDto>>("api/Products/Category");
                return categori;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
		{
            //throw new NotImplementedException();
             try
            {
                var produst = await this.httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Products");
                return produst;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductDto> GetProductId(int id)
        {
            //throw new NotImplementedException();
            var produst = await this.httpClient.GetFromJsonAsync<ProductDto>($"api/Products/{id}");
            if (produst != null)
                return produst;
            throw new Exception("product null");
        }

        public async Task<ProductDto> UpdateProduct(int id, ProductUpdateToDto productUpdateToDto)
		{
			//throw new NotImplementedException();
			try
			{
                var jsonRequest = JsonConvert.SerializeObject(productUpdateToDto);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await httpClient.PatchAsync($"api/Products/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ProductDto>();
                }
                return null;
            }
			catch (Exception)
			{

				throw;
			}
		}
	}
}
