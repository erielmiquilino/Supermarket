using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Data.Context;
using Supermarket.Data.Repository;
using Supermarket.Domain.Interfaces;

namespace Supermarket.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;Database=supermarket;Uid=root;Pwd=P@ssw0rd")
            );

            serviceDescriptors.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }
    }
}
