using Abp.Notifications;
using iRender.iDrive.Dto;

namespace iRender.iDrive.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}