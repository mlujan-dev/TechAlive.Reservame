using System.Collections.Generic;
using System.Linq;
using Google.Cloud.Firestore;
using MongoDB.Driver;
using TechAlive.Reservame.Core.DataAccess;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core
{
	public class ProductService : IProductService
	{
		private readonly IMongoCollection<Product> _products;

		public FirestoreClient FirestoreClient { get;  }
		public CollectionReference ProductsCollection { get; set; }

		public ProductService(FirestoreClient firestoreClient)
		{
			FirestoreClient = firestoreClient;
			ProductsCollection = firestoreClient.DataBase.Collection("Products");
		}

		public List<Product> Get()
		{
			var querySnapshot = ProductsCollection.GetSnapshotAsync().Result;
			var documents = querySnapshot.Documents;
			return documents.Select(snapshot => snapshot.ConvertTo<Product>()).ToList();
		}

		public Product Get(string id) =>
			_products.Find<Product>(product => product.Code == id).FirstOrDefault();

		public Product Create(Product product)
		{
			_products.InsertOne(product);
			return product;
		}

		public void Update(string id, Product productIn) =>
			_products.ReplaceOne(product => product.Code == id, productIn);

		public void Remove(Product productIn) =>
			_products.DeleteOne(product => product.Code == productIn.Code);

		public void Remove(string id) =>
			_products.DeleteOne(product => product.Code == id);
	}
}
