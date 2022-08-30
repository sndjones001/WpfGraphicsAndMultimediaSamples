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

            return services;
        }
    }
}
