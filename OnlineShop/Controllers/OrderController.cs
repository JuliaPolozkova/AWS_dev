using Amazon.SQS;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.QueueService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IAmazonSQS _sqsClient;

		public OrderController(IAmazonSQS sqsClient)
		{
			_sqsClient = sqsClient;
		}

		[HttpPost]
		public async Task<string> CheckoutAsync(ShoppingCart cart)
		{
			return await SQSService.SendMessage(_sqsClient, JsonSerializer.Serialize(cart));
		}
	}
}
