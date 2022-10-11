using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<LoginView>();
            services.AddSingleton<HomeView>();
            serviceProvider = services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //var startWindow = serviceProvider.GetService<LoginView>();
            var startWindow = serviceProvider.GetService<HomeView>();
            startWindow?.Show();
        }
    }
}
