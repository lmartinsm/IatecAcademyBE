using AtividadeRPiatec.Infra;
using AtividadeRPiatec.Interface;
using AtividadeRPiatec.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AtividadeRPiatec.Models;
using AtividadeRPiatec.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//configuração do contexto Db
builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMvc();

//injeção de dependencia
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API");
});

app.MapGet("/Livro/{id}", ([FromRoute] int id, [FromServices] IRepository<Livro> livro) =>
{
    LivroService service = new LivroService(livro);

    return Results.Ok(service.GetLivroById(id));
});

app.MapPost("/Livro", ([FromBody] Livro model, [FromServices] IRepository<Livro> livro) =>
{
    LivroService service = new LivroService(livro);
    service.AddLivro(model);
    livro.SaveChanges();
});



app.Run();

