using Ecommerce.DataProvider;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Handler;
using Ecommerce.Handler.ConfigureServices;
using Ecommerce_API.GlobalExceptionHandler;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader();
    });
});
ConfigureServicesAction.Execute(builder.Services);
//Register Providers
ConfigureDataProviderAction.Execute(builder.Services);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader();
    });
});
builder.Services.AddDbContext<AppDBContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "localhost",
        ValidAudience = "localhost",
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["jwtconfig:key"])),
        ClockSkew = TimeSpan.Zero
    };

});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseCors("AllowOrigin");

app.MapControllers();
var loggerFactory = app.Services.GetService<ILoggerFactory>();
if (app.Environment.IsDevelopment())
{
    loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
