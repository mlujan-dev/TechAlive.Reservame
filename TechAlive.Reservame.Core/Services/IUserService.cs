using System.Collections.Generic;
using System.Threading.Tasks;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core.Services
{
	public interface IUserService
	{
		List<User> Get();
		User Get(string tokenId);
		Task<User> Register(UserDto userDto);
		Task<User> Update(string tokenId, UserDto userDto);
		void Remove(User user);
		void Remove(string tokenId);
	}
}
