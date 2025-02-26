using DotNetProjectScaffold.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DotNetProjectScaffold
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.Configure();

            var serviceProvider = services.BuildServiceProvider();

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();

            base.OnStartup(e);
        }
    }
}
