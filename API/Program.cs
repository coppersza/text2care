using StackExchange.Redis;
using Core.Entities.Identity;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);
//add services to container

builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddControllers();  

var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

builder.Services.AddDbContext<StoreContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("MySQLDefaultConnection");
        if (String.IsNullOrEmpty(connectionString))
            connectionString = "server=localhost;user=text2care;password=Text2care@13;database=text2careapidb";
        options.UseMySql(connectionString, serverVersion);
    });
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("MySQLIdentityConnection");
        if (String.IsNullOrEmpty(connectionString))
            connectionString = "server=localhost;user=text2care;password=Text2care@13;database=text2careapidb";        
        options.UseMySql(connectionString, serverVersion);
    });    

// builder.Services.AddDbContext<StoreContext>(x =>
//     x.UseMySql(builder.Configuration.GetConnectionString("MySQLDefaultConnection")));
// builder.Services.AddDbContext<AppIdentityDbContext>(x => 
//     x.UseMySQL(builder.Configuration.GetConnectionString("MySQLIdentityConnection")));

builder.Services.AddSingleton<IConnectionMultiplexer, ConnectionMultiplexer>(c => {
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("RedisLocal"), true);
    configuration.ClientName = "Text2CareApp-RedisCacheProvider";
    configuration.ReconnectRetryPolicy = new ExponentialRetry(5000, 10000);
    return ConnectionMultiplexer.Connect(configuration);
});

builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddSwaggerDocumentation();
builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });
});

//Confiugure HTTP request pipeline
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaggerDocumentation();
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

// app.UseRouting();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Content")), RequestPath="/content"
});
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToController("Index", "Fallback");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<StoreContext>();
        await context.Database.MigrateAsync();
        await StoreContextSeed.SeedAsync(context, loggerFactory);

        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        var identityContext = services.GetRequiredService<AppIdentityDbContext>();
        await identityContext.Database.MigrateAsync();
        await AppIdentityDbContextSeed.SeedUsersAsync(userManager, roleManager);

    }catch(Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred during migration.");
    }
}
await app.RunAsync();

