using Newtonsoft.Json;

namespace TechAlive.Reservame.Core.Dto.FirebaseResponse
{
	public class FirebaseNotificationResponse
	{
		[JsonProperty("multicast_id")]
        public long MulticastId { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("failure")]
        public bool Failure { get; set; }

        [JsonProperty("canonical_ids")]
        public short CanonicalIds { get; set; }

        [JsonProperty("results")]
        public dynamic Results { get; set; }
	}
}
