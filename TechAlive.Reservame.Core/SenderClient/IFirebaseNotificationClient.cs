using System.Threading.Tasks;
using TechAlive.Reservame.Core.Dto;
using TechAlive.Reservame.Core.Dto.FirebaseNotification;

namespace TechAlive.Reservame.Core.SenderClient
{
	public interface IFirebaseNotificationClient
	{
		Task<ApiResponse> Send(NotificationMessage notificationMessage);
	}
}
