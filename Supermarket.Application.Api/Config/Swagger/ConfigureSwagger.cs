using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Supermarket.Application.Api.Config.Swagger
{
    public class ConfigureSwagger
    {

        public static void ConfigureDependenciesService(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1",
                   new OpenApiInfo
                   {
                       Title = "Supermarket-Ws",
                       Version = "v1",
                       Description = "Controle suas compras de supermercado",
                       Contact = new OpenApiContact
                       {
                           Name = "Eriel Miquilino",
                       }
                   });
           });
        }
    }
}
