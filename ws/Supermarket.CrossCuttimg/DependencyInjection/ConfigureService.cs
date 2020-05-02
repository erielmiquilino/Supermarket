using Microsoft.Extensions.DependencyInjection;
using Supermarket.Domain.Interfaces.Services.Products;
using Supermarket.Domain.Interfaces.Services.Users;
using Supermarket.Service.Services.Products;
using Supermarket.Service.Services.Users;

namespace Supermarket.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddTransient<IProductService, ProductService>();
            serviceDescriptors.AddTransient<IUserService, UserService>();
            serviceDescriptors.AddTransient<ILoginService, LoginService>();
        }
    }
}
