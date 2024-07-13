using Application.Common.Pipelines;
using FluentValidation;


using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
			return services;
        }
    }
}
