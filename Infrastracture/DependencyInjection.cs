using Infrastracture.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Common.Pipelines;

namespace Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DB")));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
			return services;
        }
    }
}
