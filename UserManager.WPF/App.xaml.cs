using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UserManager.WPF.Extensions;
using UserManager.WPF.Services;

// Implement
// TODO updating/adding/removing user / user groups
// TODO change user group for user
// TODO improve visuals
// TODO request caching
// TODO lazy loading

namespace UserManager.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }


        public App()
        {
            ServiceCollection services = new ServiceCollection();
            Services = ConfigureServices(services);

        }


        private IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddWebApi("https://localhost:7106/api/");
            return services.BuildServiceProvider();
        }


        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
