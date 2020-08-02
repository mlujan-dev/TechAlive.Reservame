using Google.Cloud.Firestore;

namespace TechAlive.Reservame.Core.Model
{
	[FirestoreData]
	public class ProductType
	{
		[FirestoreProperty]
		public string Code { get; set; }

		[FirestoreProperty]
		public string Description { get; set; }	
	}
}
