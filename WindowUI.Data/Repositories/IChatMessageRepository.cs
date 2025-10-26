namespace WindowUI.Data.Repositories
{
    using WindowUI.Domain.Models;

    public interface IChatMessageRepository
    {
        public IAsyncEnumerable<ChatMessage> GetChatMessages();

        public Task SaveChatMessage(ChatMessage chatMessage);
    }
}
