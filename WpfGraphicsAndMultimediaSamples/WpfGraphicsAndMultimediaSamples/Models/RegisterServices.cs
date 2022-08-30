using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGraphicsAndMultimediaSamples.GraphicsEffects;

namespace WpfGraphicsAndMultimediaSamples.Models
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<MainViewModel>();
            services.AddTransient<NavigationBarViewModel>();
            services.AddTransient<NavigationBarViewModel>();
        }
    }
}
