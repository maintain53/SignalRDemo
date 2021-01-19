using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Hubs
{
    public class NotificationHub:Hub<IClientNotification>
    {
        public async Task SendNotification(User user)
        {
            await Clients.Others.SendUserCreationNotification(user);
        }
    }
}
