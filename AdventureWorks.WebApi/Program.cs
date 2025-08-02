using System.Text;
using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Settings;
using AdventureWorks.Domain.Entities;
using AdventureWorks.Infrastructure.Persistence;
using AdventureWorks.Infrastructure.Repositories;
using AdventureWorks.Infrastructure.Services;
using AdventureWorks.WebApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddDbContext<AuthinticationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDb")));

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));

builder.Services.AddScoped<IAuthService, AuthService>();


var jwtSettings = builder.Configuration.GetSection("JWTSettings").Get<JWTSettings>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
    };
});


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IReportingRepository, ReportingRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQueryHandler).Assembly));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var authDb = scope.ServiceProvider.GetRequiredService<AuthinticationDbContext>();
    
    if (!authDb.Users.Any())
    {
        authDb.Users.Add(new AppUser { Username = "admin", Password = "1234", Role = "Admin" });
        authDb.SaveChanges();
    }
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestTimingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();

