using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Model;
using TechAlive.Reservame.Core.Services;

namespace TechAlive.Reservame.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CommerceController : ControllerBase
	{
		private readonly CommerceService _commerceService;

		public CommerceController(CommerceService commerceService)
		{
			_commerceService = commerceService;
		}

		[HttpGet("{tokenId}")]
		public ActionResult<Commerce> Get(string tokenId)
		{
			var clientRequest = _commerceService.Get(tokenId);

			if (clientRequest == null)
			{
				return NotFound();
			}

			return clientRequest;
		}

		[HttpGet]
		public ActionResult<List<Commerce>> Get()
		{
			return _commerceService.Get().Take(10).ToList();
		}

		[HttpPost]
		public ActionResult<Commerce> Create(CommerceDto commerceDto)
		{
			var commerce = _commerceService.Register(commerceDto).Result;
			return new ActionResult<Commerce>(commerce);
		}

		[HttpPut("{tokenId}/{commerce}")]
		public ActionResult<Commerce> Update(string tokenId, CommerceDto commerce)
		{
			var clientRequest = _commerceService.Get(tokenId);

			if (clientRequest == null)
			{
				return NotFound();
			}

			return _commerceService.Update(tokenId, commerce).Result;
		}

		[HttpDelete("{tokenId}")]
		public IActionResult Delete(string tokenId)
		{
			var order = _commerceService.Get(tokenId);

			if (order == null)
			{
				return NotFound();
			}

			_commerceService.Remove(tokenId);

			return new AcceptedResult();
		}
	}
}
