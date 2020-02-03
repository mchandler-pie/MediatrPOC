using System.Collections.Generic;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Packages.Pie.Pipeline.Behaviors;

namespace Packages.Pie.Pipeline.Bootstrap
{
    public static class ServiceCollectionExtension
    {
        public static void AddFluentValidation(this IServiceCollection services, IEnumerable<Assembly> assemblies,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            services.Add(new ServiceDescriptor(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>), lifetime));

            services.AddValidatorsFromAssemblies(assemblies, lifetime);
        }
    }
}
