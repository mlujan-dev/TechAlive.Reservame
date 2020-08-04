using System.Collections.Generic;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core
{
	public interface IClientService
	{
		List<Client> Get();
		Client Get(string id);
		Client Create(Client product);
		void Update(string id, Client productIn);
		void Remove(Client productIn);
		void Remove(string id);
	}
}
