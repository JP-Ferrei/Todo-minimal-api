using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using todo.Entities;

namespace todo.Context;

public class TodoContext : DbContext
{
  
  public DbSet<Tarefa> Tarefas { get; set; }

  public TodoContext(DbContextOptions<TodoContext> opt): base(opt)
  {
      
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("User ID=postgres;Password=DB@ccess;Host=localhost;Port=5432;Database=Todo;Pooling=true;");

}
