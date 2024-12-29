using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Ion.Server.Hubs;

[Authorize]
public class AnnouncementChatHub : Hub
{
    private readonly string userId = 1.ToString();

    public async Task Send(string message,  string receiverId, int announcementId)
    {
        await Clients
            .Groups(userId, receiverId)
            .SendAsync("Receive", message, userId, announcementId);
    }

    public override Task OnConnectedAsync()
    {
        Groups.AddToGroupAsync(Context.ConnectionId, userId);

        return base.OnConnectedAsync();
    }
}