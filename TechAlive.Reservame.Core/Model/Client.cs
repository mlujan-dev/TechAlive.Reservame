namespace TechAlive.Reservame.Core.Model
{
	public class Client
	{
		public string Id { get; set; }
		public string Code { get; set; }
		public string BusinessName { get; set; }
		public string[] EmailAddresses { get; set; }
		public string[] PhoneNumbers { get; set; }
	}
}
