namespace WindowUI.Data
{
    using Microsoft.EntityFrameworkCore;
    using WindowUI.Data.Entities;

    public class WindowUiContext : DbContext
    {
        public DbSet<TodoItemEntity> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=windowui.db");
        }
    }   
}
