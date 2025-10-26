namespace WindowUI.Web.Services
{
    using WindowUI.Data.Repositories;
    using WindowUI.Domain.Models;

    public class ChatMessageService : IChatMessageService
    {
        private ILogger _logger;
        private IServiceScopeFactory _serviceScopeFactory;

        public ChatMessageService(
            ILogger<ChatMessageService> logger,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<List<ChatMessage>> GetMessagesAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<IChatMessageRepository>();

            return await repository.GetChatMessages().ToListAsync();
        }

        public async Task SendMessageAsync(ChatMessage message)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<IChatMessageRepository>();

            await repository.SaveChatMessage(message);
        }
    }
}
