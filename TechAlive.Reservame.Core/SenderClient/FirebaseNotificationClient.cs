using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Dto.FirebaseNotification;
using TechAlive.Reservame.Core.Dto.FirebaseResponse;

namespace TechAlive.Reservame.Core.SenderClient
{
	public class FirebaseNotificationClient : IFirebaseNotificationClient
	{
		private IRestClient RestClient { get; }

		public FirebaseNotificationClient()
		{
			RestClient = new RestClient("https://fcm.googleapis.com/fcm/send");
		}

		public async Task<ApiResponse> Send(NotificationMessage notificationMessage)
		{
			var stopWatch = Stopwatch.StartNew();
			var response = await SendNotification(notificationMessage);
			stopWatch.Stop();

			return response.Success
				? ApiResponse.Ok(stopWatch.Elapsed, JsonConvert.SerializeObject(notificationMessage))
				: ApiResponse.Fail((int)HttpStatusCode.BadRequest, response.MulticastId.ToString(), stopWatch.Elapsed,
					JsonConvert.SerializeObject(notificationMessage));
		}

		private async Task<FirebaseNotificationResponse> SendNotification(NotificationMessage notificationMessage)
		{
			var request = new RestRequest(string.Empty, DataFormat.Json)
				.AddJsonBody(JsonConvert.SerializeObject(notificationMessage)).AddHeader("Authorization", "key=AAAAfglftXg:APA91bEPuTy8UvAB4n3DOFDoXB07arbUy7eYPrYV3MJxCfsT--WXzm3yd7HuYIXuvmZLV8wX7rpfydCTKSRsuBazEVDNCmDbEUsgrDAWZw1X1zVgyeXC6RvIu2T2uxc1lB_1vtrxWZeH");
			return await RestClient.PostAsync<FirebaseNotificationResponse>(request);
		}
	}
}
