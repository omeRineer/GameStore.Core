using Business.Helpers;
using Business.Services.Internal;
using Core.Utilities.Helpers;
using Core.Utilities.ServiceTools;
using Entities.Enum.Type;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Models.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Filters
{
    public class Benchmark : ActionFilterAttribute, IAsyncActionFilter
    {
        readonly int MaxMilliseconds;
        readonly Stopwatch Stopwatch;
        readonly LogType[] logTo;
        readonly NotificationService NotificationService;

        public Benchmark(int maxTimeout = 5000, params LogType[] logTypes)
        {
            MaxMilliseconds = maxTimeout;
            Stopwatch = Stopwatch.StartNew();
            logTo = logTypes;
            NotificationService = StaticServiceProvider.GetService<NotificationService>();
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Stopwatch.Reset();
            Stopwatch.Start();

            await next();

            Stopwatch.Stop();

            double milliSeconds = Math.Round(Stopwatch.Elapsed.TotalMilliseconds, 2);

            if (milliSeconds > MaxMilliseconds)
                await AlertToAsync(context, milliSeconds);
        }

        private async Task AlertToAsync(ActionExecutingContext context, double milliSeconds)
        {
            foreach (var logType in logTo)
            {
                switch (logType)
                {
                    case LogType.Console:
                        break;

                    case LogType.Debug:
                        break;

                    case LogType.Notification:
                        await NotificationService.PushAsync(new PushNotificationMessage
                        {
                            Type = "system",
                            Level = "warning",
                            Sender = "System",
                            Title = $"Benchmark Uyarısı",
                            Content = $"{context.ActionDescriptor.DisplayName} çalışma süresi {milliSeconds}ms",
                            ContentType  = "text"
                        });
                        break;

                }
            }
        }
    }
}
