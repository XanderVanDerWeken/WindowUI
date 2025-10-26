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

        public async Task SaveTodoItemAsync(TodoItem todoItem)
        {
            if (todoItem.Id == 0)
            {
                // Create new item
                _dbContext.TodoItems.Add(new TodoItemEntity
                {
                    Title = todoItem.Title,
                    IsCompleted = todoItem.IsCompleted
                });
            }
            else
            {
                // Update existing item
                var existingEntity = await _dbContext.TodoItems.FindAsync(todoItem.Id);
                if (existingEntity != null)
                {
                    existingEntity.Title = todoItem.Title;
                    existingEntity.IsCompleted = todoItem.IsCompleted;
                }
            }
            
            await _dbContext.SaveChangesAsync();
        }

        public async IAsyncEnumerable<TodoItem> GetAllTodoItemsAsync()
        {
            var todoItems = _dbContext.TodoItems.AsAsyncEnumerable();

            await foreach (var entity in todoItems)
            {
                yield return new TodoItem
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    IsCompleted = entity.IsCompleted
                };
            }
        }
    }   
}
