using SignalRDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Hubs
{
    public interface IClientNotification
    {
        Task SendUserCreationNotification(User user);
    }
}
