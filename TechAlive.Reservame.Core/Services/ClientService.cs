using System;
using System.Collections.Generic;
using System.Linq;
using Google.Cloud.Firestore;
using TechAlive.Reservame.Core.DataAccess;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core.Services
{
	public class ClientService : IClientService
	{
		public FirestoreClient FirestoreClient { get; }
		public CollectionReference ProductsCollection { get; set; }

		public ClientService(FirestoreClient firestoreClient)
		{
			FirestoreClient = firestoreClient;
			ProductsCollection = firestoreClient.DataBase.Collection("Clients");
		}

		public List<Client> Get()
		{
			try
			{
				var querySnapshot = ProductsCollection.GetSnapshotAsync().Result;
				var documents = querySnapshot.Documents;
				return documents.Select(snapshot => snapshot.ConvertTo<Client>()).ToList();
			}
			catch (Exception ex)
			{
				return new List<Client>
				{
					new Client {Code = ex.Message, BusinessName = ex.StackTrace }
				};
			}
		}

		public Client Get(string id) =>
			Get().First();

		public Client Create(Client product)
		{
			return Get().First();
		}

		public void Update(string id, Client productIn)
		{
		}

		public void Remove(Client productIn)
		{

		}

		public void Remove(string id)
		{
		}
	}
}
