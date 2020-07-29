namespace TechAlive.Reservame.Core.DataAccess
{
	public class DatabaseSettings : IDatabaseSettings
	{
		public string ClientsCollectionName { get; set; }
		public string ProductsCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
