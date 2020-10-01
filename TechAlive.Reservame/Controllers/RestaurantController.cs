using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Model;
using TechAlive.Reservame.Core.Services;

namespace TechAlive.Reservame.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RestaurantController : ControllerBase
	{
		private readonly RestaurantService _restaurantService;

		public RestaurantController(RestaurantService restaurantService)
		{
			_restaurantService = restaurantService;
		}

		[HttpGet("{tokenId}")]
		public ActionResult<Restaurant> Get(string tokenId)
		{
			var clientRequest = _restaurantService.Get(tokenId);

			if (clientRequest == null)
			{
				return NotFound();
			}

			return clientRequest;
		}

		[HttpGet]
		public ActionResult<List<Restaurant>> Get()
		{
			var clientRequest = _restaurantService.Get().Take(10).ToList();

			if (clientRequest == null)
			{
				return NotFound();
			}

			return clientRequest;
		}

		[HttpPost]
		public ActionResult<Restaurant> Create(RestaurantDto restaurantDto)
		{
			var restaurant = _restaurantService.Register(restaurantDto).Result;
			return new ActionResult<Restaurant>(restaurant);
		}

		[HttpPut("{tokenId}/{restaurant}")]
		public async Task<IActionResult> Update(string tokenId, RestaurantDto restaurant)
		{
			var clientRequest = _restaurantService.Get(tokenId);

			if (clientRequest == null)
			{
				return NotFound();
			}

			await _restaurantService.Update(tokenId, restaurant);

			return new AcceptedResult();
		}

		[HttpDelete("{tokenId}")]
		public IActionResult Delete(string tokenId)
		{
			var order = _restaurantService.Get(tokenId);

			if (order == null)
			{
				return NotFound();
			}

			_restaurantService.Remove(tokenId);

			return new AcceptedResult();
		}
	}
}
