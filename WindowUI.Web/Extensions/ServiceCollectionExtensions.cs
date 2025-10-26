namespace WindowUI.Web.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using WindowUI.Data;
    using WindowUI.Data.Repositories;
    using WindowUI.Web.Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWindowServices(this IServiceCollection services)
        {
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
            services.AddScoped<IChatMessageRepository, ChatMessageRepository>();

            services.AddSingleton<ITodoItemService, TodoItemService>();
            services.AddSingleton<IChatMessageService, ChatMessageService>();

            return services;
        }

        public static IServiceCollection AddWindowDb(this IServiceCollection services)
        {
            services.AddDbContext<WindowUiContext>(options =>
            {
                options.UseSqlite("Data Source=windowui.db");
            });

            return services;
        }
    }
}
