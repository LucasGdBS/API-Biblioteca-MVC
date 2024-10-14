using BibliotecaAPI.Data;
using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Services.Autor; 

using DotNetEnv; // Lib para usar variáveis de ambiente

Env.Load(); // Carrega as variaveis de ambiente dentro do código

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAutorInterface, AutorService>(); // Adiciona o serviço de autor

var connectionString = Environment.GetEnvironmentVariable("DefaultConnection"); // Puxa a variável de ambiente
builder.Services.AddDbContext<AppDbContext>(options => 
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
