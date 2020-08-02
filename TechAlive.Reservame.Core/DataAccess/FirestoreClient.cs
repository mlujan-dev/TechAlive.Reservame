using System;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

namespace TechAlive.Reservame.Core.DataAccess
{
	public class FirestoreClient
	{
		private const string ProjectId = "reservame-f3adc";
		public FirestoreDb DataBase { get; set; }

		public FirestoreClient()
		{
			Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:/reservame-f3adc-firebase-adminsdk-btm0v-f166c8d858.json");
			GoogleCredential.GetApplicationDefault();
			DataBase = FirestoreDb.CreateAsync(ProjectId).Result;
		}
	}
}
