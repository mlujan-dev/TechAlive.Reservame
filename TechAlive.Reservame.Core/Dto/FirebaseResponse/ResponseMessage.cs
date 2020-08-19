using Newtonsoft.Json;

namespace TechAlive.Reservame.Core.Dto.FirebaseResponse
{
	public class ResponseMessage
	{
		[JsonProperty("message_id")]
		public string MessageId { get; set; }
	}
}