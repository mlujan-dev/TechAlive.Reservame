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
		private readonly MongoMongoClientService _mongoMongoClientService;

		public ClientsController(MongoMongoClientService mongoMongoClientService)
		{
			_mongoMongoClientService = mongoMongoClientService;
		}

		[HttpGet]
		public ActionResult<List<Client>> Get() =>
			_mongoMongoClientService.Get();

		[HttpGet("{id:length(24)}", Name = "GetClient")]
		public ActionResult<Client> Get(string id)
		{
			var product = _mongoMongoClientService.Get(id);

			if (product == null)
			{
				return NotFound();
			}

			return product;
		}

		[HttpPost]
		public ActionResult<Client> Create(Client client)
		{
			_mongoMongoClientService.Create(client);

			return CreatedAtRoute("GetClient", new { id = client.Id }, client);
		}

		[HttpPut("{id:length(24)}")]
		public IActionResult Update(string id, Client productIn)
		{
			var product = _mongoMongoClientService.Get(id);

			if (product == null)
			{
				return NotFound();
			}

			_mongoMongoClientService.Update(id, productIn);

			return NoContent();
		}

		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var product = _mongoMongoClientService.Get(id);

			if (product == null)
			{
				return NotFound();
			}

			_mongoMongoClientService.Remove(product.Id);

			return NoContent();
		}
	}
}
