namespace WindowUI.Web.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using WindowUI.Domain.Models;
    using WindowUI.Web.Services;

    public class ChatHub : Hub
    {
        private readonly IChatMessageService _chatMessageService;

        public ChatHub(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }

        public async Task SendMessage(string authorName, string message)
        {
            await _chatMessageService.SaveMessageAsync(new ChatMessage
            {
                AuthorName = authorName,
                Message = message,
            });

            await Clients.All.SendAsync("ReceiveMessage", authorName, message);
        }
    }
}
