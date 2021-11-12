using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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
    await ctx.SaveChangesAsync();

    return Results.Created($"/tarefas/{tarefa.Id}", tarefa);
});

app.MapGet("/tarefa", async (TodoContext ctx) =>
{
    var tarefas = await ctx.Tarefas.ToListAsync();

    return tarefas == null ? Results.NoContent() : Results.Ok(tarefas);
});

app.MapGet("/tarefa/{id}", async (TodoContext ctx, Guid id) =>
{
    var tarefa = await ctx.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

    return tarefa == null ? Results.NoContent() : Results.Ok(tarefa);
});

app.MapDelete("/tarefa/{id}", async (TodoContext ctx, Guid id) =>
{
    var tarefa = await ctx.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
    if (tarefa == null)
        return Results.BadRequest("Não existe tarefa com esse id no sistema");

    ctx.Tarefas.Remove(tarefa);
    
    return Results.NoContent();
});

app.MapPut("/tarefa/{id}", async (TodoContext ctx, Guid id, Tarefa tarefa) =>
{
    ctx.Entry(tarefa).State = EntityState.Modified;
    await ctx.SaveChangesAsync();
    return tarefa;
});



app.Run();
