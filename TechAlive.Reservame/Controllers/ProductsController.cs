using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechAlive.Reservame.Core;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly ProductService _productService;

		public ProductsController(ProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public ActionResult<List<Product>> Get() =>
			_productService.Get();

		[HttpGet("{id:length(24)}", Name = "GetProduct")]
		public ActionResult<Product> Get(string id)
		{
			var product = _productService.Get(id);

			if (product == null)
			{
				return NotFound();
			}

			return product;
		}

		[HttpPost]
		public ActionResult<Product> Create(Product product)
		{
			_productService.Create(product);

			return CreatedAtRoute("GetProduct", new { id = product.Code }, product);
		}

		[HttpPut("{id:length(24)}")]
		public IActionResult Update(string id, Product productIn)
		{
			var product = _productService.Get(id);

			if (product == null)
			{
				return NotFound();
			}

			_productService.Update(id, productIn);

			return NoContent();
		}

		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var product = _productService.Get(id);

			if (product == null)
			{
				return NotFound();
			}

			_productService.Remove(product.Code);

			return NoContent();
		}
	}
}