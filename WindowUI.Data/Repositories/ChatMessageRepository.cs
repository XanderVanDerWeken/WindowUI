namespace WindowUI.Data.Repositories
{
    using WindowUI.Data.Entities;
    using WindowUI.Domain.Models;

    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly WindowUiContext _dbContext;

        public ChatMessageRepository(WindowUiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async IAsyncEnumerable<ChatMessage> GetChatMessages()
        {
            var messageEntities = _dbContext.ChatMessages.AsAsyncEnumerable();

            await foreach (var entity in messageEntities)
            {
                yield return new ChatMessage
                {
                    Id = entity.Id,
                    AuthorName = entity.AuthorName,
                    Message = entity.Message,
                };
            }
        }

        public async Task SaveChatMessage(ChatMessage chatMessage)
        {
            _dbContext.ChatMessages.Add(new ChatMessageEntity
            {
                AuthorName = chatMessage.AuthorName,
                Message = chatMessage.Message,
            });

            await _dbContext.SaveChangesAsync();
        }
    }
}
