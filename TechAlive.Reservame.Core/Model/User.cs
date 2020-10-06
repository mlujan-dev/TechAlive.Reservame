using Google.Cloud.Firestore;

namespace TechAlive.Reservame.Core.Model
{
	[FirestoreData]
	public class User
	{
		[FirestoreDocumentId]
		public string Id { get; set; }

		[FirestoreProperty]
		public string UserName { get; set; }

		[FirestoreProperty]
		public string MailAddress { get; set; }

		[FirestoreProperty]
		public string PhoneNumber { get; set; }
	}
}