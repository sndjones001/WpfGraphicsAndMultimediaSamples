using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGraphicsAndMultimediaSamples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            _serviceProvider = RegisterProvider().BuildServiceProvider();
        }

        private IServiceCollection RegisterProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<MainWindow>();

            Models.RegisterServices.Register(services);
            GraphicsOverview.RegisterServices.Register(services);
            GraphicsEffects.RegisterServices.Register(services);
            GraphicsBrushes.RegisterServices.Register(services);

            return services;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
    }
}
