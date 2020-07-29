using System.Collections.Generic;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core
{
	public interface IProductService
	{
		List<Product> Get();
		Product Get(string id);
		Product Create(Product product);
		void Update(string id, Product productIn);
		void Remove(Product productIn);
		void Remove(string id);
	}
}
