using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ConfToolAndMore.Server.Hubs
{
    public class ConferencesHub : Hub
    {
        public async Task BroadcastNewConferenceAdded()
        {
            await Clients.All.SendAsync("NewConferenceAdded");
        }
    }
}
