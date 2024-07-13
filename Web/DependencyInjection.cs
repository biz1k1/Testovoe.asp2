using Infrastracture.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Web.Contracts;
using Web.Services;

namespace Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddTransient<IRecordService, RecordService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
