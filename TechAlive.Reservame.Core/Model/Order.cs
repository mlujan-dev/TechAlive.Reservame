using System;

namespace TechAlive.Reservame.Core.Model
{
	public class Order
	{
		public int Id { get; set; }
		public string HashCode { get; set; }
		public DateTime CreatedDateTime { get; set; }
		public DateTime EstimatedEnd { get; set; }
		public DateTime RealEnd { get; set; }
		public OrderDetail[] OrderDetails { get; set; }
	}
}
