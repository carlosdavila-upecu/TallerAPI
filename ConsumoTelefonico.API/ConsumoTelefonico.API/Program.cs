using ConsumoTelefonico.API;
using Data;
using Data.Contexto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Negocio.Repositorio;
using Negocio.Repositorio.IRepositorio;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Taller API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please Bearer and then token in the field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });
}); //Swagger

//DbContext
builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Identity
builder.Services.AddIdentity<Usuario, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//Configuracion Jwt
var sectionConfiguracionJwt = builder.Configuration.GetSection("ConfiguracionJwt");
builder.Services.Configure<ConfiguracionJwt>(sectionConfiguracionJwt);

//Autenticacion
var configuracionJwt = sectionConfiguracionJwt.Get<ConfiguracionJwt>();
var secreto = Encoding.ASCII.GetBytes(configuracionJwt.Secreto);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secreto),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Repositorios
builder.Services.AddScoped<IRegistroRepositorio, RegistroRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Seguridad
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
