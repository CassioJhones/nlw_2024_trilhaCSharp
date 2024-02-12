using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RocketSeatSolution.API.Contratos;
using RocketSeatSolution.API.Filters;
using RocketSeatSolution.API.Repositories;
using RocketSeatSolution.API.Repositories.DataAccess;
using RocketSeatSolution.API.Services;
using RocketSeatSolution.API.UseCases.Auctions.GetCurrent;
using RocketSeatSolution.API.UseCases.Offers.CreateOffer;
using System.Security.Cryptography.Xml;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.AddSecurityDefinition
        ("Bearer", new OpenApiSecurityScheme
        {
            Description = @"Autorização JWT usando o header via Bearer scheme.
                          Insira 'Bearer ' e o seu token no espaço abaixo
                          Exemplo: 'Bearer 123456789'",
            Name = "Autorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        options.AddSecurityRequirement
        (new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
            },
                new List<string>()
            }

        });
    }); ;

builder.Services.AddScoped<AutenticacaoUsuarioAttribute>();
builder.Services.AddScoped<IUsuarioLogado, UsuarioLogado>();
builder.Services.AddScoped<CreateOfferUseCase>();
builder.Services.AddScoped<GetCurrentAuctionUseCase>();
builder.Services.AddScoped<IRepositorioLeilao, RepositorioLeilao>();
builder.Services.AddScoped<IRepositorioOferta, RepositorioOferta>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

builder.Services.AddDbContext<RocketSeatSolutioinDBContext>(options =>
{
    options.UseSqlite(@"Data Source=C:\Users\cassi\Downloads\leilaoDbNLW.db");
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
