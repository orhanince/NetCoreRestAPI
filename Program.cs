using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
builder.Services.AddControllers(); 
// Register services
builder.Services.AddScoped<IAuthService, AuthService>(); 
builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IEncryptService, EncryptService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
// Register Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();

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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<CustomForbiddenMiddleware>();
app.UseMiddleware<CustomUnauthorizedMiddleware>();
app.UseMiddleware<GlobalResponseMiddleware>();
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

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
