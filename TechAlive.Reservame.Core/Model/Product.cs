using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TechAlive.Reservame.Core.Model
{
	public class Product
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("Code")]
		public string Code { get; set; }

		[BsonElement("Description")]
		public string Description { get; set; }

		[BsonElement("ProductType")]
		public ProductType ProductType { get; set; }

		[BsonElement("Price")]
		public double Price { get; set; }
	}
}
