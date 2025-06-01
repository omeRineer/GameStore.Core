using Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Internal
{
    public class NotificationService
    {
        readonly RabbitMqClientService _rabbitMqClientService;

        public NotificationService(RabbitMqClientService rabbitMqClientService)
        {
            _rabbitMqClientService = rabbitMqClientService;
        }

        public async Task PushAsync(PushNotificationMessage message)
            => await _rabbitMqClientService.PushAsync("Notification_Queue", message);
    }
}
