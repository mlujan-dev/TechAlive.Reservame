using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using TechAlive.Reservame.Core.DataAccess;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core.Services
{
	public class CommerceService : ICommerceService
	{
		public FirestoreClient FirestoreClient { get; }
		public CollectionReference ShopsCollection { get; set; }

		public CommerceService(FirestoreClient firestoreClient)
		{
			FirestoreClient = firestoreClient;
			ShopsCollection = firestoreClient.DataBase.Collection("Commerce");
		}

		public List<Commerce> Get()
		{
			var querySnapshot = ShopsCollection.GetSnapshotAsync().Result;
			var documents = querySnapshot.Documents;
			return documents.Select(snapshot => snapshot.ConvertTo<Commerce>()).ToList();
		}

		public Commerce Get(string tokenId)
		{
			var docRef = ShopsCollection.Document(tokenId);
			var snapshot = docRef.GetSnapshotAsync().Result;
			return snapshot.ConvertTo<Commerce>();
		}

		public async Task<Commerce> Register(CommerceDto commerce)
		{
			var created = await ShopsCollection.AddAsync(new Commerce
			{
				BusinessName = commerce.CommerceName, 
				GeoPoint = new GeoPoint(commerce.Latitude, commerce.Longitude),
				Address = commerce.Address,
				Capacity = commerce.Capacity,
				MailAddress = commerce.MailAddress,
				PhoneNumber = commerce.PhoneNumber,
				LogoTypeImage = commerce.LogoTypeImage
			});

			return Get(created.Id);
		}

		public async Task<Commerce> Update(string tokenId, CommerceDto commerce)
		{
			var docRef = ShopsCollection.Document(tokenId);
			await docRef.UpdateAsync(new Dictionary<string, object>
			{
				{"CommerceName", commerce.CommerceName}, 
				{"GeoPoint", new GeoPoint(commerce.Latitude, commerce.Longitude)},
				{"Address", commerce.Address},
				{"Capacity", commerce.Capacity},
				{"MailAddress", commerce.MailAddress},
				{"PhoneNumber", commerce.PhoneNumber},
				{"LogoTypeImage", commerce.LogoTypeImage}
			});

			var snapshot = docRef.GetSnapshotAsync().Result;
			return snapshot.ConvertTo<Commerce>();
		}

		public void Remove(Commerce commerce)
		{
			Remove(commerce.Id);
		}

		public void Remove(string tokenId)
		{
			var docRef = ShopsCollection.Document(tokenId);
			docRef.DeleteAsync();
		}
	}
}
