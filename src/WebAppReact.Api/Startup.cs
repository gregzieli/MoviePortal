using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAppReact.Api.Abstractions.Providers;
using WebAppReact.Api.Providers;
using WebAppReact.Domain.Repositories;
using WebAppReact.Infrastructure;
using WebAppReact.Infrastructure.Repositories;

namespace WebAppReact.Api
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
            services.AddDbContextPool<MoviePortalContext>(optionsAction =>
            {
                optionsAction
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), serverOptions =>
                {
                    serverOptions.MigrationsAssembly("WebAppReact.Infrastructure");
                });
            });

            services.AddAutoMapper(typeof(Startup));

            services
                .AddTransient<IMovieProvider, MovieProvider>()
                .AddTransient<IMovieRepository, MovieRepository>()
                .AddTransient<IAuthorRepository, AuthorRepository>()
                ;

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(setup =>
                setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Web API", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger()
                .UseSwaggerUI(setup =>
                {
                    setup.RoutePrefix = "";
                    setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies API V1");
                });
        }
    }
}
