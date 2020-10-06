using System.Collections.Generic;
using System.Threading.Tasks;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core.Services
{
	public interface ICommerceService
	{
		List<Commerce> Get();
		Commerce Get(string tokenId);
		Task<Commerce> Register(CommerceDto commerce);
		Task<Commerce> Update(string tokenId, CommerceDto commerce);
		void Remove(Commerce commerce);
		void Remove(string tokenId);
	}
}
