namespace WindowUI.Web.Hubs
{
    using Microsoft.AspNetCore.SignalR;

    public class ChatHub : Hub
    {
        public async Task SendMessage(string authorName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", authorName, message);
        }
    }
}
