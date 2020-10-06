using Newtonsoft.Json;

namespace TechAlive.Reservame.Core.Dto
{
	public class UserDto
	{
		[JsonProperty("user_name")]
		public string UserName { get; set; }

		[JsonProperty("mail_address")]
		public string MailAddress { get; set; }

		[JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }
	}
}
