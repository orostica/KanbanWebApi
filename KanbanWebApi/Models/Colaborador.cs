namespace KanbanWebApi.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public bool Situacao { get; set; }
        public string Linkedin { get; set; } = String.Empty;
        public Cargo? Cargo { get; set; }
        public int CargoId { get; set; }

    }
}
