using System;
using System.Collections.Generic;

namespace OnlineShop
{
	public class ShoppingCart
	{
		public int Id { get; set; }

		public List<Product> Products { get; set; } = new List<Product>();
	}
}
