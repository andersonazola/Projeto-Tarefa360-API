

using DataAccess.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Projeto360.Aplicacao;
using Projeto360.Aplicacao.Interfaces;
using Projeto360.Repositorio;
using Projeto360.Repositorio.Interfaces;
using Projeto360.Servicos.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<ITarefaAplicacao, TarefaAplicacao>();
builder.Services.AddScoped<IProjetoAplicacao, ProjetoAplicacao>();


// Adicione as interfaces de banco de dados
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IProjetoRepositorio, ProjetoRepositorio>();

// Adicione os serviços

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


builder.Services.AddScoped<IJsonPlaceHolderServico, JsonPlaceHolderServico>();

builder.Services.AddControllers();

// Adicionar o serviço de banco de dados
builder.Services.AddDbContext<Projeto360Contexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("projetoDB")));


// Saiba mais sobre a configuracão do Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
