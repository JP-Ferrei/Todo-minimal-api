namespace todo.Entities
{
  public class Tarefa
  {
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public DateTimeOffset DataPrazo { get; set; }
    public DateTimeOffset DataCriacao { get; set; }
    public bool Finalizada { get; set; }

    public Tarefa(string titulo, DateTimeOffset dataPrazo)
    {
      this.Id = Guid.NewGuid(); 
      this.Titulo = titulo;
      this.DataPrazo = dataPrazo;
      this.DataCriacao = DateTimeOffset.UtcNow;
      this.Finalizada = false;

    }
  }
}