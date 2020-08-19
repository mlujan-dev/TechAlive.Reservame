using System.Collections.Generic;
using System.Threading.Tasks;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core.Services
{
	public interface IRestaurantService
	{
		List<Restaurant> Get();
		Restaurant Get(string tokenId);
		Task<Restaurant> Register(RestaurantDto restaurant);
		Task Update(string tokenId, RestaurantDto restaurant);
		void Remove(Restaurant restaurant);
		void Remove(string tokenId);
	}
}
