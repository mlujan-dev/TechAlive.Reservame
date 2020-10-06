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

		[HttpGet("ByCommerce/{commerceToken}")]
		public ActionResult<List<ClientRequest>> GetByCommerce(string commerceToken)
		{
			var clientRequests = _deviceRequestService.GetByCommerce(commerceToken);
			return clientRequests ?? new List<ClientRequest>();
		}

		[HttpPost]
		public ActionResult<ClientRequest> Register(ClientRequestRegister clientRequestRegister)
		{
			return _deviceRequestService.Create(clientRequestRegister).Result;
		}

		[HttpPut("{id}/{status}")]
		public ActionResult<ClientRequest> UpdateStatus(string id, string status)
		{
			var clientRequest = _deviceRequestService.Get(id);

			if (clientRequest == null)
			{
				return NotFound();
			}

			return _deviceRequestService.Update(id, status).Result;
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
