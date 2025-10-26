namespace WindowUI.Data.Entities
{
    public class ChatMessageEntity
    {
        public int Id { get; set; }
        public required string AuthorName { get; set; }
        public required string Message { get; set; }
    }
}
