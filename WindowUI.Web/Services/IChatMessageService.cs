namespace WindowUI.Web.Services
{
    using WindowUI.Domain.Models;

    public interface IChatMessageService
    {
        public Task SendMessage(ChatMessage message);

        public Task<List<ChatMessage>> GetMessages();
    }
}
