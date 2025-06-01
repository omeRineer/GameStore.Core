using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Message
{
    public class PushNotificationMessage
    {
        public string Type { get; set; }
        public string Sender { get; set; }
        public string Level { get; set; }
        public string Title { get; set; }
        public string ContentType { get; set; }
        public string? Content { get; set; }
        public List<string>? Targets { get; set; }

        public Dictionary<string, object>? Custom { get; set; }
    }
}
