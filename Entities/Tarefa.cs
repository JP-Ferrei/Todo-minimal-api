namespace todo.Entities
{
  public class Tarefa
  {
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public DateTime DataPrazo { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Finalizada { get; set; }

    public Tarefa(string titulo, DateTime dataPrazo)
    {
      this.Id = Guid.NewGuid(); 
      this.Titulo = titulo;
      this.DataPrazo = dataPrazo;
      this.DataCriacao = DateTime.Now;
      this.Finalizada = false;

    }
  }
}