//using API.Interfaces;
using API.Interfaces;
using API.Middlewares;
using API.Models;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetService<IConfiguration>();
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("")));
builder.Services.AddDbContext<MyDbContext>(option => option.UseSqlServer(config.GetConnectionString("dbcs")));


/////////////////// : Repositories and Services Start: ///////////////////

builder.Services.AddScoped<IEmployee, EmployeeRepository>(); // Register the repository
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<IDepartment, DeprtmentRepository>();
builder.Services.AddScoped<DepartmentService>();
//builder.Services.AddScoped<IAuth, AuthRepository>();
//builder.Services.AddScoped<AuthService>();
builder.Services.AddTransient<IAuth, AuthRepository>();
builder.Services.AddTransient<AuthService>();

/////////////////// : Repositories and Services End: ///////////////////


//builder.Services.AddTransient<IAuthService, IAuthService>();
//builder.Services.AddTransient<IEmployeeService, IEmployeeService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new
        SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}/*JwtBearerDefaults.AuthenticationScheme*/).AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        //ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Audinece"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
//    };
//});
//builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
