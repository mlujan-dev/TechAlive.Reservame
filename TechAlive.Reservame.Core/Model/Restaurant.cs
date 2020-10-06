using System;
using Google.Cloud.Firestore;

namespace TechAlive.Reservame.Core.Model
{
	[FirestoreData]
	public class Restaurant
	{
		[FirestoreDocumentId]
		public string Id { get; set; }

		[FirestoreProperty]
		public string BusinessName { get; set; }

		[FirestoreProperty]
		public GeoPoint GeoPoint { get; set; }

		[FirestoreProperty]
		public string Address { get; set; }

		[FirestoreProperty]
		public int Capacity { get; set; }

		[FirestoreProperty]
		public string MailAddress { get; set; }

		[FirestoreProperty]
		public string PhoneNumber { get; set; }

		[FirestoreProperty]
		public string Category { get; set; }

		[FirestoreProperty]
		public string LogoTypeImage { get; set; }
	}
}
