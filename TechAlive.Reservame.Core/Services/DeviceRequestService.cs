using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using TechAlive.Reservame.Core.DataAccess;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Dto.FirebaseNotification;
using TechAlive.Reservame.Core.Model;
using TechAlive.Reservame.Core.SenderClient;

namespace TechAlive.Reservame.Core.Services
{
	public class DeviceRequestService : IDeviceRequestService
	{
		private readonly FirebaseNotificationClient _notificationClient;
		public CollectionReference DeviceRequestsCollection { get; set; }

		public DeviceRequestService(FirestoreClient firestoreClient, FirebaseNotificationClient notificationClient)
		{
			_notificationClient = notificationClient;
			DeviceRequestsCollection = firestoreClient.DataBase.Collection("device_requests");
		}

		public List<ClientRequest> Get()
		{
			var querySnapshot = DeviceRequestsCollection.GetSnapshotAsync().Result;
			var documents = querySnapshot.Documents;
			return documents.Select(snapshot => snapshot.ConvertTo<ClientRequest>()).ToList();
		}

		public ClientRequest Get(string id)
		{
			var docRef = DeviceRequestsCollection.Document(id);
			var snapshot = docRef.GetSnapshotAsync().Result;
			return snapshot.ConvertTo<ClientRequest>();
		}

		public List<ClientRequest> GetByRestaurant(string restaurantToken)
		{
			var query = DeviceRequestsCollection.WhereEqualTo("RestaurantId", restaurantToken);
			var querySnapshot = query.GetSnapshotAsync().Result;
			var documents = querySnapshot.Documents;
			return documents.Select(snapshot => snapshot.ConvertTo<ClientRequest>()).ToList();
		}

		public async Task<ClientRequest> Create(ClientRequestRegister request)
		{
			var created = await DeviceRequestsCollection.AddAsync(new ClientRequest{DeviceToken = request.DeviceToken, CreatedDateTime = DateTime.UtcNow, Status = "Created", ClientsQuantity = request.ClientsQuantity, RestaurantId = request.RestaurantToken });
			var notificationResponse = await _notificationClient.Send(new NotificationMessage(request.DeviceToken, "Su solicitud fue recibida"));
			//Loguear o actualizar estado de pedido
			return Get(created.Id);
		}

		public async Task Update(string id, string status)
		{
			var docRef = DeviceRequestsCollection.Document(id);
			await docRef.UpdateAsync(new Dictionary<string, object> { { "Status",status} });

			var snapshot = docRef.GetSnapshotAsync().Result;
			var clientRequest = snapshot.ConvertTo<ClientRequest>();

			await _notificationClient.Send(new NotificationMessage(clientRequest.DeviceToken, clientRequest.Status));
		}

		public void Remove(string id)
		{
			var docRef = DeviceRequestsCollection.Document(id);
			docRef.DeleteAsync();
		}
	}
}
