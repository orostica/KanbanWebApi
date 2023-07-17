namespace KanbanWebApi.Dto
{
    public class UpdateCargoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
    }
}
