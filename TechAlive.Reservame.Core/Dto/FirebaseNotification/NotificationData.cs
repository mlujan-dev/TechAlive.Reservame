using Newtonsoft.Json;

namespace TechAlive.Reservame.Core.Dto.FirebaseNotification
{
	public class NotificationData
	{
		[JsonProperty("image")]
		public string ImageUri { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("key_1")]
		public string FirstKey { get; set; }

		[JsonProperty("key_2")]
		public string SecondKey { get; set; }
	}
}
