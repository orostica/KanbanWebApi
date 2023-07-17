using System.Text.Json.Serialization;

namespace KanbanWebApi.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Nome { get; set; }=String.Empty;
        public string Descricao { get; set; } = String.Empty;
        public bool Situacao { get; set; }

        [JsonIgnore]
        public List<Colaborador> Colaboradores { get; set; }

    }
}
