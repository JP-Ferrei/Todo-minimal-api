using Microsoft.AspNetCore.Builder;
using todo.Context;
using todo.Entities;
using todo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapPost("/tarefa", async (TodoContext ctx, TarefaModel model) =>
{
  var tarefa = new Tarefa(model.Titulo, model.DataPrazo);

  await ctx.Tarefas.AddAsync(tarefa);

  return Results.Created($"/tarefas/{tarefa.Id}", tarefa);
});

app.Run();
