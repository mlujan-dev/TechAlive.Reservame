using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechAlive.Reservame.Core.Model;
using TechAlive.Reservame.Core.Services;

namespace TechAlive.Reservame.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ClientsController : ControllerBase
	{
		private readonly ClientService _clientService;

		public ClientsController(ClientService clientService)
		{
			_clientService = clientService;
		}

		[HttpGet]
		public ActionResult<List<Client>> Get() =>
			_clientService.Get();

		[HttpGet("{id:length(24)}", Name = "GetClient")]
		public ActionResult<Client> Get(string id)
		{
			var product = _clientService.Get(id);

			if (product == null)
			{
				return NotFound();
			}

			return product;
		}

		[HttpPost]
		public ActionResult<Client> Create(Client client)
		{
			_clientService.Create(client);

			return CreatedAtRoute("GetClient", new { id = client.Id }, client);
		}

		[HttpPut("{id:length(24)}")]
		public IActionResult Update(string id, Client productIn)
		{
			var product = _clientService.Get(id);

			if (product == null)
			{
				return NotFound();
			}

			_clientService.Update(id, productIn);

			return NoContent();
		}

		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var product = _clientService.Get(id);

			if (product == null)
			{
				return NotFound();
			}

			_clientService.Remove(product.Id);

			return NoContent();
		}
	}
}
