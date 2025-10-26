namespace WindowUI.Data.Repositories
{
    using WindowUI.Domain.Models;

    public interface ITodoItemRepository
    {
        public Task SaveTodoItemAsync(TodoItem newTodoItem);

        public IAsyncEnumerable<TodoItem> GetAllTodoItemsAsync();
    }   
}
