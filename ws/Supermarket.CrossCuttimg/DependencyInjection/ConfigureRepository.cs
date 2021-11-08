using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Data.Context;
using Supermarket.Data.Implementations;
using Supermarket.Data.Repository;
using Supermarket.Domain.Interfaces;
using Supermarket.Domain.Interfaces.Repositories;
using System;

namespace Supermarket.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceDescriptors)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            serviceDescriptors.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;Database=supermarket;Uid=root;Pwd=P@ssw0rd", serverVersion)
            );

            serviceDescriptors.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceDescriptors.AddScoped<IUserRepository, UserRepository>();
            serviceDescriptors.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
