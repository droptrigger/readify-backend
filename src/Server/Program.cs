using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ServerLibrary.Data;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Implementations;
using ServerLibrary.Repositories.Interfaces;
using ServerLibrary.Services.Implementations;
using ServerLibrary.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    // Добавляем поддержку JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


// START
builder.Services.AddDbContext<ReadifyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new InvalidOperationException("Error to connection!"));
});

builder.Services.Configure<JwtSection>(builder.Configuration.GetSection("JwtSection"));

// Register repositories
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRefreshRepository, RefreshRepository>();

// Register services
builder.Services.AddScoped<IAuthentificatonService, AuthentificatonService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuth(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFileServer();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
