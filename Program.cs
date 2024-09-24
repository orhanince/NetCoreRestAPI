using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NetCoreRestAPI.Data;
using NetCoreRestAPI.Middleware;
using NetCoreRestAPI.Repository;
using NetCoreRestAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NetCoreRestAPI.Data.MyAppContext>(options =>
    options.UseSqlServer("Server=127.0.0.1,1433;Database=NetCoreRestApi;User Id=SA;Password=YourPassword123; Encrypt=True; TrustServerCertificate=True"));
    //jdbc:sqlserver://localhost:1433;encrypt=true;trustServerCertificate=true;

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 
// Register services
builder.Services.AddScoped<IAuthService, AuthService>(); 
builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IEncryptService, EncryptService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
// Register Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Register JWT 
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = jwtSettings.GetSection("Key")?.Value;
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key ?? throw new ArgumentNullException(nameof(key))))
    };
});

var app = builder.Build();
app.UseMiddleware<CheckJsonDataMiddleware>();  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.UseStaticFiles();
/**
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<CustomForbiddenMiddleware>();
app.UseMiddleware<CustomUnauthorizedMiddleware>();
app.UseMiddleware<GlobalResponseMiddleware>();
*/
//app.UseExceptionHandler(options => {ExceptionHandlerMiddleware})
app.MapControllers();

app.MapGet("/", () =>
{
    var jsonResponse = new
            {
                Message = "NetCoreRestAPI",
                Date = DateTime.UtcNow,
                Status = "Success"
            };
    return jsonResponse;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

using (IServiceScope scope = app.Services.CreateScope())
{
    MyAppContext context = scope.ServiceProvider.GetService<MyAppContext>()!;
    try
    {
        context.Database.Migrate();
    }
    catch (Exception)
    {
        throw;
    }
}
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
