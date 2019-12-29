using Microsoft.Extensions.DependencyInjection;
using Supermarket.Domain.Interfaces.Services.Products;
using Supermarket.Service.Services.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddTransient<IProductService, ProductService>();
        }
    }
}
