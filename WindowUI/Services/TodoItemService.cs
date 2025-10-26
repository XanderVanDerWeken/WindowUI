namespace WindowUI.Services
{
    using WindowUI.Data.Repositories;
    using WindowUI.Domain.Models;

    public class TodoItemService : ITodoItemService
    {
        private readonly ILogger _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TodoItemService(ILogger<TodoItemService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task SaveTodoItemAsync(TodoItem todoItem)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<ITodoItemRepository>();

            await repository.SaveTodoItemAsync(todoItem);
        }

        public async Task<List<TodoItem>> GetAllTodoItemsAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<ITodoItemRepository>();

            return await repository.GetAllTodoItemsAsync().ToListAsync();
        }
    }   
}
