using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraphicsAndMultimediaSamples.GraphicsBrushes
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<WpfGraphicsBrushViewModel>();
            services.AddTransient<WpfGraphicsSolidBrushViewModel>();
            services.AddTransient<WpfGraphicsLinearGradientBrushViewModel>();
        }
    }
}
