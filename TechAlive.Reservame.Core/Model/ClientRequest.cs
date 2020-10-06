using System;
using Google.Cloud.Firestore;

namespace TechAlive.Reservame.Core.Model
{
	[FirestoreData]
	public class ClientRequest
	{
		[FirestoreDocumentId]
		public string Id { get; set; }

		[FirestoreProperty]
		public string DeviceToken { get; set; }

		[FirestoreProperty]
		public string CommerceToken { get; set; }

		[FirestoreProperty]
		public DateTime CreatedDateTime { get; set; }

		[FirestoreProperty]
		public DateTime EndDatime { get; set; }

		[FirestoreProperty]
		public int ClientsQuantity { get; set; }

		[FirestoreProperty]
		public string Status { get; set; }
	}
}
