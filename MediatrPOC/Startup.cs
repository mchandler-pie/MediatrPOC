using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Packages.Pie.Pipeline.Behaviors;
using Packages.Pie.Pipeline.Bootstrap;
using Packages.Validators;
using Pie.Shared.Settings.Json;

namespace MediatrPOC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson();

            services.AddMediatR(typeof(ValidationBehavior<,>).Assembly);

            services.AddFluentValidation(new [] {typeof(ValidatorBase<>).Assembly});
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ScoringHandler<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RatingHandler<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            JsonConfig.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
