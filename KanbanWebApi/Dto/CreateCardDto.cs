namespace KanbanWebApi.Dto
{
    public class CreateCardDto
    {
        public string Nome { get; set; }
        public int Posicao { get; set; }
        public string Cor { get; set; }
        public int TarefaId { get; set; }
    }
}
