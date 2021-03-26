using ApiToka.Core.Interfaces.Repositories;
using ApiToka.Core.Interfaces.Services;
using ApiToka.Core.Services;
using ApiToka.Infrastrucure.Data;
using ApiToka.Infrastrucure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ApiToka
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<TOKAContext> (options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Toka")));
            
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            services.AddTransient<IPersonaService, PersonaService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Cors
            services.AddCors(o => o.AddPolicy(MyAllowSpecificOrigins, builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            }));

            //Formato Json
            services.AddMvc().AddJsonOptions(options => {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
