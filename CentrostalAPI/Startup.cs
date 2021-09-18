using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentrostalAPI.Config;
using CentrostalAPI.DB;
using CentrostalAPI.Helpers;
using CentrostalAPI.IServices;
using CentrostalAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CentrostalAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            JwtHelper.loadConfig(Configuration);

            services.AddDbContext<ApplicationDbContext>(options => {
                var sqlconnection = Configuration.GetConnectionString("sqlConnection");
                //var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
                //options.UseLoggerFactory(loggerFactory)
                //    .EnableSensitiveDataLogging()
                //    .UseSqlServer(sqlconnection);

                options.UseSqlServer(sqlconnection);
            });
            services.configureCors();

            services.AddAutoMapper(typeof(MapperInitializer));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IItemsService, ItemsService>();
            services.AddScoped<IOrdersService, OrdersService>();

            services.configureAuthentication();

            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CentrostalAPI", Version = "v1" });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CentrostalAPI v1"));
            }

            app.configureExceptionHandler(logger);
            app.UseHttpsRedirection();

            app.UseCors("AllowAll");


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
