using Newtonsoft.Json;

namespace TechAlive.Reservame.Core.Dto.FirebaseNotification
{
	public class Notication
	{
		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("image")]
		public string ImageUri { get; set; }
	}
}
