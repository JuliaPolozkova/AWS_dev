using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineShop.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ShoppingCartController : ControllerBase
	{
		private readonly RDSContext _context;
		private readonly IConfiguration _config;

		public ShoppingCartController(RDSContext context, IConfiguration config)
		{
			_context = context;
			_config = config;
		}

		[HttpGet]
		public async Task<ShoppingCart> GetAsync(int id)
		{
			ShoppingCartDAL cart = new ShoppingCartDAL(_context);
			return await cart.GetAsync(id);
		}

		[HttpDelete]
		public async Task DeleteAsync(int id)
		{
			ShoppingCartDAL cart = new ShoppingCartDAL(_context);
			await cart.DeleteAsync(id);
		}

		[HttpPut]
		public async Task<string> AddAsync(string name, int id)
		{
			//ShoppingCartDAL cart = new ShoppingCartDAL(_context);
			//await cart.SaveAsync(name, id);

			//only for test localy
			ShoppingCart cart = new ShoppingCart();
			cart.Products.Add(new Product { Name = name });

			string orderServiceEndPoint = _config.GetValue<string>("OrderService");
			var client = new HttpClient();
			HttpResponseMessage response = client.PostAsync(orderServiceEndPoint, 
				new StringContent(JsonSerializer.Serialize(cart), 
				Encoding.UTF8, "application/json")).Result; ;
			return response.StatusCode.ToString();
		}
	}
}
