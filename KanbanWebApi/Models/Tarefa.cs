namespace KanbanWebApi.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public List<Card> Cards { get; set; }

    }
}
