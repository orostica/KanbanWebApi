using System.Text.Json.Serialization;

namespace KanbanWebApi.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public int Posicao { get; set; }
        public string Cor { get; set; } = String.Empty;

        [JsonIgnore]
        public Tarefa Tarefa { get; set; }
        public int TarefaId { get; set; }

    }
}
