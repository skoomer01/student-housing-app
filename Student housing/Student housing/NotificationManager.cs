using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class NotificationManager
    {
        private List<string> notifications = new List<string>();

        public string[] GetNotificationList()
        {
            return notifications.ToArray();
        }

        public void AddNotification(string notification)
        {
            notifications.Add(notification);
        }
    }
}
