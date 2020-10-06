using System.Collections.Generic;
using System.Threading.Tasks;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core.Services
{
	public interface IDeviceRequestService
	{
		List<ClientRequest> Get();
		ClientRequest Get(string id);
		List<ClientRequest> GetByRestaurant(string restaurantToken);
		Task<ClientRequest> Create(ClientRequestRegister request);
		Task<ClientRequest> Update(string id, string status);
		void Remove(string id);
	}
}
