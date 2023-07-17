using KanbanWebApi.Data;
using KanbanWebApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace KanbanWebApi.Repositories.CardRepository
{
    public class CardRepository : ICardRepository
    {
        private readonly DataContext _dataContext;

        public CardRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Card>> Get()
        {
            var cards = await _dataContext.Card
            .Include (x => x.Tarefa)
            .ToListAsync();

            return cards;
        }
        public async Task<Card?> GetById(int id)
        {
            var card = await _dataContext.Card
             .Where(x => x.Id == id)
             .FirstOrDefaultAsync();

            return card;
        }
        public async Task<List<Card>?> Create(CreateCardDto request)
        {
            var tarefa = await _dataContext.Tarefa.FindAsync(request.TarefaId);
            if (tarefa == null)
            {
                return null;
            }

            var novoCard = new Card
            {
                Nome = request.Nome,
                Posicao = request.Posicao,
                Cor = request.Cor,
                TarefaId = request.TarefaId,
                Tarefa = tarefa
            };

            _dataContext.Add(novoCard);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Card.ToListAsync();
        }
        public async Task<List<Card>?> Update(UpdateCardDto request)
        {

            var card = await _dataContext.Card.FindAsync(request.Id);
            if (card == null)
            {
                return null;
            }

            var tarefa = await _dataContext.Tarefa.FindAsync(card.TarefaId);
            if (tarefa == null)
            {
                return null;
            }

            card.Nome = request.Nome;
            card.Posicao = request.Posicao;
            card.Cor = request.Cor;
            card.TarefaId = request.TarefaId;
            card.Tarefa = tarefa;

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Card.ToListAsync();
        }
        public async Task<List<Card>?> Delete(int id)
        {
            var card = await _dataContext.Card.FindAsync(id);
            if (card is null)
            {
                return null;
            }

            _dataContext.Card.Remove(card);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Card.ToListAsync();
        }
    }
}
