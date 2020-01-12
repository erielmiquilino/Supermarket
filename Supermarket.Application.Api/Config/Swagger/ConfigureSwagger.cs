using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;

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
               c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
                   In = ParameterLocation.Header,
                   Description = "Entre com o Token JWT",
                   Name = "Authorization",
                   Type = SecuritySchemeType.ApiKey
               });

               c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                       new OpenApiSecurityScheme
                       {
                           Reference = new OpenApiReference
                           {
                               Id = "Bearer",
                               Type = ReferenceType.SecurityScheme
                           }
                       },
                       new List<string>()
                   },
                }); ;
           });
        }
    }
}
