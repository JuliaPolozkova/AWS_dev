using Amazon.Util;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop
{
	public class ShoppingCartDAL : IShoppingCartDAL
	{
		private readonly RDSContext _context;
		public ShoppingCartDAL(RDSContext context)
		{
			_context = context;
		}

		public async Task SaveAsync(string name, int id)
		{
			ShoppingCart cart = _context.ShoppingCarts.Single(c => c.Id == id);
			if (cart == null)
			{
				cart = new ShoppingCart();
				cart.Products.Add(new Product { Name = name });
				_context.ShoppingCarts.Add(cart);
			}
			else
			{
				cart.Products.Add(new Product { Name = name });
			}

			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			_context.ShoppingCarts.Remove(_context.ShoppingCarts.Single(b => b.Id == id));
			await _context.SaveChangesAsync();
		}

		public async Task<ShoppingCart> GetAsync(int id)
		{
			return await _context.ShoppingCarts.SingleAsync(b => b.Id == id);
		}
	}
}
