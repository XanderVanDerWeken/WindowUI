namespace WindowUI.Models
{
    public class Application
    {
        public required string Name { get; set; }
        public required string Icon { get; set; }
        public Type? ComponentType { get; set; }
    }
}
