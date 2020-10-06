using Google.Apis.Auth.OAuth2;
using Google.Apis.CloudResourceManager.v1;
using Google.Cloud.Firestore;

namespace TechAlive.Reservame.Core.DataAccess
{
	public class FirestoreClient
	{
		private const string ProjectId = "modified-wonder-258716";
		public FirestoreDb DataBase { get; set; }

		public FirestoreClient()
		{
			GoogleCredential.GetApplicationDefault()
				.CreateScoped(CloudResourceManagerService.Scope.CloudPlatform);
			DataBase = FirestoreDb.CreateAsync(ProjectId).Result;
		}
    }
}