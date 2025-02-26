using DotNetProjectScaffold.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetProjectScaffold.Configuration
{
    public static class DependencyInjection
    {
        public static void Configure(this IServiceCollection services)
        {
            services.ConfigureViewModels();
            services.ConfigureViews();
        }

        private static void ConfigureViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
        }

        private static void ConfigureViews(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
        }
    }
}