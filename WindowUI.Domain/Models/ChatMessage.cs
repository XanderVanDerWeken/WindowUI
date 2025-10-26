namespace WindowUI.Domain.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public required string AuthorName { get; set; }
        public required string Message { get; set; }
    }
}
