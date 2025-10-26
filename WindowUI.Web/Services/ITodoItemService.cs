namespace WindowUI.Web.Services
{
    using WindowUI.Domain.Models;

    public interface ITodoItemService
    {
        public Task SaveTodoItemAsync(TodoItem todoItem);

        public Task<List<TodoItem>> GetAllTodoItemsAsync();
    }
}
