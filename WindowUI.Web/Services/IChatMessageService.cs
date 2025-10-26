namespace WindowUI.Web.Services
{
    using WindowUI.Domain.Models;

    public interface IChatMessageService
    {
        public Task SendMessageAsync(ChatMessage message);

        public Task<List<ChatMessage>> GetMessagesAsync();
    }
}
