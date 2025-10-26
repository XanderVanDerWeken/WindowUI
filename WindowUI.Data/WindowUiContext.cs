namespace WindowUI.Data
{
    using Microsoft.EntityFrameworkCore;
    using WindowUI.Data.Entities;

    public class WindowUiContext : DbContext
    {
        public DbSet<TodoItemEntity> TodoItems { get; set; }

        public WindowUiContext(DbContextOptions<WindowUiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItemEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.IsCompleted).HasDefaultValue(false);
            });
        }
    }
}
