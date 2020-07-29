using MongoDB.Bson.Serialization.Attributes;

namespace TechAlive.Reservame.Core.Model
{
	public class ProductType
	{
		[BsonElement("Code")]
		public string Code { get; set; }

		[BsonElement("Description")]
		public string Description { get; set; }	
	}
}
