using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Data.Context;
using Supermarket.Data.Repository;
using Supermarket.Data.Implementations;
using Supermarket.Domain.Interfaces;
using Supermarket.Domain.Interfaces.Repositories;

namespace Supermarket.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;Database=supermarket;Uid=root;Pwd=P@ssw0rd")
            );

            serviceDescriptors.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceDescriptors.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
