using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Model;
using TechAlive.Reservame.Core.Services;

namespace TechAlive.Reservame.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ClientRequestController : ControllerBase
	{
		private readonly DeviceRequestService _deviceRequestService;

		public ClientRequestController(DeviceRequestService deviceRequestService)
		{
			_deviceRequestService = deviceRequestService;
		}

		[HttpGet]
		public ActionResult<List<ClientRequest>> Get() =>
			_deviceRequestService.Get();

		[HttpGet("{id}")]
		public ActionResult<ClientRequest> Get(string id)
		{
			var clientRequest = _deviceRequestService.Get(id);

			if (clientRequest == null)
			{
				return NotFound();
			}

			return clientRequest;
		}

		[HttpGet("ByRestaurant/{restaurantToken}")]
		public ActionResult<List<ClientRequest>> GetByRestaurant(string restaurantToken)
		{
			var clientRequests = _deviceRequestService.GetByRestaurant(restaurantToken);

			if (clientRequests == null)
			{
				return NotFound();
			}

			return clientRequests;
		}

		[HttpPost]
		public ActionResult<ClientRequest> Register(ClientRequestRegister clientRequestRegister)
		{
			var clientRequest = _deviceRequestService.Create(clientRequestRegister).Result;
			return new ActionResult<ClientRequest>(clientRequest);
		}

		[HttpPut("{id}/{status}")]
		public IActionResult UpdateStatus(string id, string status)
		{
			var clientRequest = _deviceRequestService.Get(id);

			if (clientRequest == null)
			{
				return NotFound();
			}

			_deviceRequestService.Update(id, status);

			return new AcceptedResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(string id)
		{
			var order = _deviceRequestService.Get(id);

			if (order == null)
			{
				return NotFound();
			}

			_deviceRequestService.Remove(id);

			return new AcceptedResult();
		}
	}
}
