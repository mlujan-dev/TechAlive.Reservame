using Newtonsoft.Json;

namespace TechAlive.Reservame.Core.Dto.FirebaseNotification
{
	public class NotificationMessage
	{
		[JsonProperty("to")]
		public string TargetDeviceKey { get; set; }

		[JsonProperty("collapse_key")]
		public string CollapseKey { get; set; }
		
		[JsonProperty("notification")]
		public Notication Notication { get; set; }

		[JsonProperty("data")]
		public NotificationData Data { get; set; }

		public NotificationMessage(string deviceKey, string message)
		{
			TargetDeviceKey = deviceKey;
			CollapseKey = "type_a";
			Notication = new Notication
			{
				Body = message,
				ImageUri =
					"https://images.vexels.com/media/users/3/127526/isolated/preview/7bc1ba5a1c3c07335da7fce3cc8b99b5-cubiertos-icono-de-servicio-redondo-by-vexels.png",
				Title = "TechAlive"
			};
			Data = new NotificationData
			{
				Title = "Notificación TechAlive",
				Body = message,
				ImageUri = "https://images.vexels.com/media/users/3/127526/isolated/preview/7bc1ba5a1c3c07335da7fce3cc8b99b5-cubiertos-icono-de-servicio-redondo-by-vexels.png",
				FirstKey = "value k1",
				SecondKey = "value k2"
			};
		}
	}
}
