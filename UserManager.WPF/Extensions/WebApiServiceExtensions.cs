using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.WPF.Services;

namespace UserManager.WPF.Extensions
{
    public static class WebApiServiceExtensions
    {
        /// <summary>
        /// Adds a WepAPI with the given base URL to this <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="baseUrl">The base URL of the WebAPI.</param>
        public static void AddWebApi(this IServiceCollection services, string baseUrl)
        {
            services.AddSingleton(new WebApi(baseUrl));
        }
    }
}
