using coreRabbitMQClient.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreRabbitMQClient.Hubs
{
    public class StocHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return Clients.Client(Context.ConnectionId).SendAsync("SetConnectionId", Context.ConnectionId);
        }
        public async Task<string> ConnectGroup(string stocName, string connectionID)
        {
            await Groups.AddToGroupAsync(connectionID, stocName);
            return $"{connectionID} is added {stocName}";
        }
        public Task PushNotify(Stoc stocData)
        {
            return Clients.Group(stocData.Name).SendAsync("ChangeStocValue", stocData);
        }
    }
}
