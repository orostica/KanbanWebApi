namespace KanbanWebApi.Dto
{
    public class CreateCargoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; } = true;
    }
}
