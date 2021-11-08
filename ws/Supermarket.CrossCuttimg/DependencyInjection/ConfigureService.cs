using Microsoft.Extensions.DependencyInjection;
using Supermarket.Domain.Interfaces.Services.Carts;
using Supermarket.Domain.Interfaces.Services.Products;
using Supermarket.Domain.Interfaces.Services.Users;
using Supermarket.Service.Services.Carts;
using Supermarket.Service.Services.Products;
using Supermarket.Service.Services.Users;

namespace Supermarket.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddTransient<IProductService, ProductService>();
            serviceDescriptors.AddTransient<IUserService, UserService>();
            serviceDescriptors.AddTransient<ICartService, CartService>();
            serviceDescriptors.AddTransient<ILoginService, LoginService>();
        }
    }
}
