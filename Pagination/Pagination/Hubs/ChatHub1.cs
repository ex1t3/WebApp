using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Pagination.Models;

namespace Pagination.Hubs
{

    public class newChatHub : Hub
    {
        static List<UserInfo> Users = new List<UserInfo>();

        public string forRandom()
        {
            Random rnd = new Random();
            int k;
            string imgLink;
            string[] imgLinks = {"https://cdn-learn.adafruit.com/assets/assets/000/012/878/thumb100/led_strips_doge.bmp?1386611464",
                "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSKowUQuwbdPnCUV7vElJulukM3aZVijcT8ik9FORTBppLkidnvxg",
            "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSVGONVZRd8B9rk1g_QkiKYgnoGeA6jDtjztpsEHNxdrOARuCOx",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3CTHub-6TEbJ-8pvwWcu8HjsqN2K6F51OgrtVeHImwTUqK4stfg" };
            k = rnd.Next(imgLinks.Length);
            return imgLink = imgLinks[k];
        }
        // Отправка сообщений
        public void Send(string name, string message)
        {
            string imgLink = forRandom();
            Clients.All.addMessage(name, message, imgLink);
        }

        // Подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;


            if (!Users.Any(x => x.ConnectionId == id))
            {
                Users.Add(new UserInfo { ConnectionId = id, Name = userName });

                // Sending message to all of users
                Clients.Caller.onConnected(id, userName, Users);
                Clients.Caller.onCheckUsers(Users);
                // Sending message to all users, but current
                Clients.AllExcept(id).onNewUserConnected(id, userName, Users);
            }
        }

        // User disconnecting
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}