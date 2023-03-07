using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models.Dto.Product
{
	public class ProductUpdateToDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageURL { get; set; }
		public decimal Price { get; set; }
		public int Qty { get; set; }
		public int CategoryId { get; set; }
	}
}
