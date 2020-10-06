using Newtonsoft.Json;

namespace TechAlive.Reservame.Core.Dto
{
	public class ClientRequestRegister
	{
		[JsonProperty("device_token")]
		public string DeviceToken { get; set; }

		[JsonProperty("commerce_token")]
		public string CommerceToken { get; set; }

		[JsonProperty("clients_quantity")]
		public int ClientsQuantity { get; set; }
	}
}
