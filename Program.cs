using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnePiece.Infraestrutura.Interfaces;
using OnePiece.Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using OnePiece.Infraestrutura.Data;
using OnePiece.Applications.Services;
using OnePiece.Applications.Validator;
using OnePiece.Applications.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<MangaValidator>();
builder.Services.AddFluentValidationAutoValidation();


builder.Services.AddAutoMapper(typeof(MappingDTOs));
builder.Services.AddScoped<IAdmin, RepAdmin>();
builder.Services.AddScoped<IUser, RepUser>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IChatRepositorie, ChatRepositorie>();
builder.Services.AddDbContext<BancoContext>(options =>
options.UseNpgsql("Host=babar.db.elephantsql.com;Database=gmenofkl;Username=gmenofkl;Password=VXUg6X-xzw7v3Lj8Ybpo2oNe3ZzSwOK6;"));

builder.Services.AddSwaggerGen(c =>
{


    // Define o esquema de segurança JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    // Define os requisitos de segurança para as operações que exigem autenticação JWT
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
            new string[] {}
        }
    });
});



var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Mudar para true em ambiente de produção
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["chaveSecreta"]!)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdministradorPolicy", policy => policy.RequireRole("Administrador"));
    
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

app.MapControllers();

app.Run();
