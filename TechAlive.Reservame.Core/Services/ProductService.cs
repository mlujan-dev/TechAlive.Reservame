﻿using System;
using System.Collections.Generic;
using System.Linq;
using Google.Cloud.Firestore;
using TechAlive.Reservame.Core.DataAccess;
using TechAlive.Reservame.Core.Model;

namespace TechAlive.Reservame.Core.Services
{
	public class ProductService : IProductService
	{
		public FirestoreClient FirestoreClient { get;  }
		public CollectionReference ProductsCollection { get; set; }

		public ProductService(FirestoreClient firestoreClient)
		{
			FirestoreClient = firestoreClient;
			ProductsCollection = firestoreClient.DataBase.Collection("Products");
		}

		public List<Product> Get()
		{
			try
			{
				var querySnapshot = ProductsCollection.GetSnapshotAsync().Result;
				var documents = querySnapshot.Documents;
				return documents.Select(snapshot => snapshot.ConvertTo<Product>()).ToList();
			}
			catch (Exception ex)
			{
				return new List<Product>
				{
					new Product {Code = ex.Message, Description = ex.StackTrace, Price = 1000 }
				};
			}
		}

		public Product Get(string id) =>
			Get().First();

		public Product Create(Product product)
		{
			return Get().First();
		}

		public void Update(string id, Product productIn)
		{
		}

		public void Remove(Product productIn)
		{

		}

		public void Remove(string id)
		{
		}
	}
}
