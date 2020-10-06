using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace TechAlive.Reservame.Core.Dto
{
	public class CommerceDto
	{
		[JsonProperty("commerce_name")]
		public string CommerceName { get; set; }

		[JsonProperty("latitude")]
		public double Latitude { get; set; }

		[JsonProperty("longitude")]
		public double Longitude { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("capacity")]
		public int Capacity { get; set; }

		[JsonProperty("mail_address")]
		public string MailAddress { get; set; }

		[JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }

		[JsonProperty("logo_type")]
		public string LogoTypeImage { get; set; }
	}
}
