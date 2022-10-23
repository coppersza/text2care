using API.Extensions;
using API.Helpers;
using API.Middleware;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace API
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddControllers();

            // services.AddDbContext<StoreContext>(x => 
            //     x.UseSqlite(_configuration.GetConnectionString("DefaultSQLiteConnection")));
            // services.AddDbContext<AppIdentityDbContext>(x => 
            //     x.UseSqlite(_configuration.GetConnectionString("DefaultSQLiteConnection")));
            
            services.AddDbContext<StoreContext>(x => 
                x.UseMySQL(_configuration.GetConnectionString("MySQLDefaultConnection")));
            services.AddDbContext<AppIdentityDbContext>(x => 
                x.UseMySQL(_configuration.GetConnectionString("MySQLDefaultConnection")));                
            
            services.AddSingleton<IConnectionMultiplexer, ConnectionMultiplexer>(c => {
                var configuration = ConfigurationOptions.Parse(_configuration.GetConnectionString("RedisLocal"), true);
                configuration.ClientName = "Text2CareApp-RedisCacheProvider";
                configuration.ReconnectRetryPolicy = new ExponentialRetry(5000, 10000);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddApplicationServices();
            services.AddIdentityServices(_configuration);
            services.AddSwaggerDocumentation();

            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
