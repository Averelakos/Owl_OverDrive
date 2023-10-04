using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using Owl.Overdrive.API.Extensions;
using Owl.Overdrive.Business.MapperProfiles;

namespace Owl.Overdrive.API
{
    public partial class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment CurrentEnviroment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment currentEnviroment)
        {
            Configuration = configuration;
            CurrentEnviroment = currentEnviroment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddControllers()
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                });
            services.AddDatabase(Configuration)
                .AddUnitOfWork()
                .AddRepositories()
                .AddFacades()
                .AddInfrastuctureServices()
                .AddConfigurations(Configuration)
                ;
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
