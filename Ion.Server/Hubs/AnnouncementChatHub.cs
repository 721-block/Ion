using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Ion.Server.Hubs;

[Authorize]
public class AnnouncementChatHub : Hub
{
    public async Task Send(string message,  string receiverId, int announcementId)
    {
        await Clients
            .Groups(1.ToString(), receiverId)
            .SendAsync("Receive", message, 1, announcementId);
    }

    public override Task OnConnectedAsync()
    {
        Groups.AddToGroupAsync(Context.ConnectionId, 1.ToString());

        return base.OnConnectedAsync();
    }
}