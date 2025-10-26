namespace WindowUI.Domain.Models
{
    public class TodoItem
    {
        public required string Title { get; set; }
        public bool IsCompleted { get; set; } = false;
    }   
}
