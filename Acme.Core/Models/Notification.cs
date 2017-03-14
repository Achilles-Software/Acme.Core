using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Achilles.Acme.Models
{
    public enum NotificationType
    {
        Success,
        Warning,
        Error
    }

    public class Notification
    {
        #region Properties

        public NotificationType Type { get; set; }
        public string Message { get; set; }

        #endregion

        public Notification( NotificationType type, string message )
        {
            Type = type;
            Message = message;
        }
    }
}