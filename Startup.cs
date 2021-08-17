using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace WishAPI
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
            // Connection string for local
            var connectionString = Configuration.GetConnectionString("WishConnection");

            // Connection string for Heroku deployment
            //var connectionString = GetHerokuConnectionString();

            services.AddEntityFrameworkNpgsql().AddDbContext<WishContext>(opt => 
                opt.UseNpgsql(TempHerokuConnString()));
            services.AddControllers();
            services.AddScoped<IWishRepository, PGSqlWishRepository>();
            services.AddScoped<IUserRepository, MockUserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

        private static string GetHerokuConnectionString()
        {
            string connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            var databaseUri = new Uri(connectionUrl);

            string db = databaseUri.LocalPath.TrimStart('/');
            string[] userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port={databaseUri.Port};Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        }

        private static string TempHerokuConnString()
        {
            return $"User ID=jzkeyzjyzfokji;Password=7dd7ed1abc1f37c3a0404f97c7112f531fb9bf951f711dfa89c296aaac6e62cf;Host=ec2-35-153-114-74.compute-1.amazonaws.com;Port=5432;Database=d4cqk75d5tbrlg;Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        }
    }
}
