using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		private static readonly List<string> Products = new List<string>
		{
			"Boots", "Dress", "Bikini", "Hat", "Bag", "Hoodie"
		};

		private readonly ILogger<ProductController> _logger;

		public ProductController(ILogger<ProductController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<Product> Get()
		{
			int i = -1;
			return Products.Select(index => new Product
			{
				Id = i++,
				Name = Products[i]
			})
			.ToArray();
		}

		[HttpPut]
		public IEnumerable<Product> Add(string name)
		{
			Products.Add(name);
			int i = -1;
			return Products.Select(index => new Product
			{
				Id = i++,
				Name = Products[i]
			})
			.ToArray();
		}
	}
}
