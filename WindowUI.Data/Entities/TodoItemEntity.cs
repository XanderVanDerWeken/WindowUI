namespace WindowUI.Data.Entities
{
    public class TodoItemEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
