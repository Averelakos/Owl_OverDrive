using Microsoft.AspNetCore.Builder;
using Owl.Overdrive.API.Extensions;

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
            services.AddControllers();
            services.AddDatabase(Configuration)
                .AddUnitOfWork()
                .AddRepositories();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
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
