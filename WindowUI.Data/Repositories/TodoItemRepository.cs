namespace WindowUI.Data.Repositories
{
    using WindowUI.Data.Entities;
    using WindowUI.Domain.Models;

    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly WindowUiContext _dbContext;

        public TodoItemRepository(WindowUiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveTodoItemAsync(TodoItem newTodoItem)
        {
            _dbContext.TodoItems.Add(new TodoItemEntity
            {
                Title = newTodoItem.Title,
                IsCompleted = newTodoItem.IsCompleted
            });
            await _dbContext.SaveChangesAsync();
        }

        public async IAsyncEnumerable<TodoItem> GetAllTodoItemsAsync()
        {
            var todoItems = _dbContext.TodoItems.AsAsyncEnumerable();

            await foreach (var entity in todoItems)
            {
                yield return new TodoItem
                {
                    Title = entity.Title,
                    IsCompleted = entity.IsCompleted
                };
            }
        }
    }   
}
