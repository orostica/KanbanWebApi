namespace KanbanWebApi.Dto
{
    public class UpdateCardDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Posicao { get; set; }
        public string Cor { get; set; }
        public int TarefaId { get; set; }
    }
}
