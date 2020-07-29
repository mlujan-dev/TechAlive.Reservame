namespace TechAlive.Reservame.Core.DataAccess
{
	public interface IDatabaseSettings
	{
		string ClientsCollectionName { get; set; }
		string ProductsCollectionName { get; set; }
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
	}
}
