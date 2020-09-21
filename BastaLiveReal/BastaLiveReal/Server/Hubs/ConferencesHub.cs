using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BastaLiveReal.Server.Hubs
{
    public class ConferencesHub : Hub
    {
        public async Task BroadcastNewConferenceAdded()
        {
            await Clients.All.SendAsync("NewConferenceAdded");
        }
    }
}
