﻿using Core.Entities.Concrete.ProcessGroups.Enums.Types;
using Core.Extensions;
using Core.Utilities.ResultTool;
using Core.Utilities.ServiceTools;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Models.Enterprise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public static class NotificationHelper
    {
        readonly static IBus Bus;

        static NotificationHelper()
        {
            Bus = StaticServiceProvider.GetService<IBus>();
        }

        public static async Task PublishAsync(string title, NotificationTypeEnum notificationType, object content)
        {
            await Bus.Publish(new CreateNotificationMessage
            {
                Type = notificationType,
                Title = title,
                Content = content.JsonSerialize()
            });
        }

        public static void Publish(string title, NotificationTypeEnum notificationType, object content)
        {
            Bus.Publish(new CreateNotificationMessage
            {
                Type = notificationType,
                Title = title,
                Content = content.JsonSerialize()
            });
        }
    }
}
