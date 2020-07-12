using AutoMapper;
using ErrorMonitoring.Dominio.Interfaces;
using ErrorMonitoring.Dominio.Services;
using ErrorMonitoring.Infra.Data.Contexts;
using ErrorMonitoring.Infra.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ErrorMonitoring.API
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
            services.AddControllers();
            services.AddDbContext<ApiContext>();
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddScoped<IProjectsService, ProjectsService>();
            services.AddScoped<IProjectsRepository, ProjectsRepository>();

            services.AddScoped<ILogsService, LogsService>();
            services.AddScoped<ILogsRepository, LogsRepository>();
            services.AddAutoMapper(typeof(Startup));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "ErrorMonitoring",
                        Version = "v1",
                        Description = "WebApi Error Monitoring"
                    });

                });

            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "v1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
