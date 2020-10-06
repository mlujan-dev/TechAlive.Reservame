using Microsoft.AspNetCore.Mvc;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Model;
using TechAlive.Reservame.Core.Services;

namespace TechAlive.Reservame.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly UserService _userService;

		public UserController(UserService userService)
		{
			_userService = userService;
		}

		[HttpGet("{tokenId}")]
		public ActionResult<User> Get(string tokenId)
		{
			var request = _userService.Get(tokenId);

			if (request == null)
			{
				return NotFound();
			}

			return request;
		}

		[HttpPost]
		public ActionResult<User> Create(UserDto userDto)
		{
			var user = _userService.Register(userDto).Result;
			return new ActionResult<User>(user);
		}

		[HttpPut("{tokenId}/{user}")]
		public ActionResult<User> Update(string tokenId, UserDto userDto)
		{
			var clientRequest = _userService.Get(tokenId);

			if (clientRequest == null)
			{
				return NotFound();
			}

			_userService.Update(tokenId, userDto);

			return _userService.Get(tokenId);
		}

		[HttpDelete("{tokenId}")]
		public IActionResult Delete(string tokenId)
		{
			var order = _userService.Get(tokenId);

			if (order == null)
			{
				return NotFound();
			}

			_userService.Remove(tokenId);

			return new AcceptedResult();
		}
	}
}
