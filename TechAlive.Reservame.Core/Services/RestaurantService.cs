using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using TechAlive.Reservame.Core.DataAccess;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core.Services
{
	public class RestaurantService : IRestaurantService
	{
		public FirestoreClient FirestoreClient { get; }
		public CollectionReference RestaurantsCollection { get; set; }

		public RestaurantService(FirestoreClient firestoreClient)
		{
			FirestoreClient = firestoreClient;
			RestaurantsCollection = firestoreClient.DataBase.Collection("Restaurants");
		}

		public List<Restaurant> Get()
		{
			var querySnapshot = RestaurantsCollection.GetSnapshotAsync().Result;
			var documents = querySnapshot.Documents;
			return documents.Select(snapshot => snapshot.ConvertTo<Restaurant>()).ToList();
		}

		public Restaurant Get(string tokenId)
		{
			var docRef = RestaurantsCollection.Document(tokenId);
			var snapshot = docRef.GetSnapshotAsync().Result;
			return snapshot.ConvertTo<Restaurant>();
		}

		public async Task<Restaurant> Register(RestaurantDto restaurant)
		{
			var created = await RestaurantsCollection.AddAsync(new Restaurant
			{
				BusinessName = restaurant.BusinessName, 
				GeoPoint = new GeoPoint(restaurant.Latitude, restaurant.Longitude),
				Address = restaurant.Address,
				Capacity = restaurant.Capacity,
				MailAddress = restaurant.MailAddress,
				PhoneNumber = restaurant.PhoneNumber,
				LogoTypeImage = restaurant.LogoTypeImage
			});

			return Get(created.Id);
		}

		public async Task<Restaurant> Update(string tokenId, RestaurantDto restaurant)
		{
			var docRef = RestaurantsCollection.Document(tokenId);
			await docRef.UpdateAsync(new Dictionary<string, object>
			{
				{"BusinessName", restaurant.BusinessName}, 
				{"GeoPoint", new GeoPoint(restaurant.Latitude, restaurant.Longitude)},
				{"Address", restaurant.Address},
				{"Capacity", restaurant.Capacity},
				{"MailAddress", restaurant.MailAddress},
				{"PhoneNumber", restaurant.PhoneNumber},
				{"LogoTypeImage", restaurant.LogoTypeImage}
			});

			var snapshot = docRef.GetSnapshotAsync().Result;
			return snapshot.ConvertTo<Restaurant>();
		}

		public void Remove(Restaurant restaurant)
		{
			Remove(restaurant.Id);
		}

		public void Remove(string tokenId)
		{
			var docRef = RestaurantsCollection.Document(tokenId);
			docRef.DeleteAsync();
		}
	}
}
