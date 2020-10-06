using Google.Cloud.Firestore;

namespace TechAlive.Reservame.Core.Model
{
	[FirestoreData]
	public class Product
	{
		[FirestoreProperty]
		public string Id { get; set; }

		[FirestoreProperty]
		public string Code { get; set; }

		[FirestoreProperty]
		public string Description { get; set; }

		[FirestoreProperty]
		public ProductType ProductType { get; set; }

		[FirestoreProperty]
		public double Price { get; set; }
	}
}
