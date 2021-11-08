using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Data.Context;

namespace Supermarket.Application.Api.Extensions
{
    public static class MigrationsExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var myContext = scope.ServiceProvider.GetRequiredService<MyContext>();
            myContext.Database.Migrate();
        }
    }
}
