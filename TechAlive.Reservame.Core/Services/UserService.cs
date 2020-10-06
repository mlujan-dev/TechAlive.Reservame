using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using TechAlive.Reservame.Core.DataAccess;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core.Services
{
	public class UserService : IUserService
	{
		public FirestoreClient FirestoreClient { get; }
		public CollectionReference UsersCollection { get; set; }

		public UserService(FirestoreClient firestoreClient)
		{
			FirestoreClient = firestoreClient;
			UsersCollection = firestoreClient.DataBase.Collection("Users");
		}

		public List<User> Get()
		{
			var querySnapshot = UsersCollection.GetSnapshotAsync().Result;
			var documents = querySnapshot.Documents;
			return documents.Select(snapshot => snapshot.ConvertTo<User>()).ToList();
		}

		public User Get(string tokenId)
		{
			var docRef = UsersCollection.Document(tokenId);
			var snapshot = docRef.GetSnapshotAsync().Result;
			return snapshot.ConvertTo<User>();
		}

		public async Task<User> Register(UserDto userDto)
		{
			var created = await UsersCollection.AddAsync(new User
			{
				UserName = userDto.UserName,
				MailAddress = userDto.MailAddress,
				PhoneNumber = userDto.PhoneNumber
			});

			return Get(created.Id);
		}

		public async Task<User> Update(string tokenId, UserDto userDto)
		{
			var docRef = UsersCollection.Document(tokenId);
			await docRef.UpdateAsync(new Dictionary<string, object>
			{
				{"UserName", userDto.UserName},
				{"MailAddress", userDto.MailAddress},
				{"PhoneNumber", userDto.PhoneNumber}
			});

			var snapshot = docRef.GetSnapshotAsync().Result;
			return snapshot.ConvertTo<User>();
		}

		public void Remove(User user)
		{
			Remove(user.Id);
		}

		public void Remove(string tokenId)
		{
			var docRef = UsersCollection.Document(tokenId);
			docRef.DeleteAsync();
		}
	}
}
