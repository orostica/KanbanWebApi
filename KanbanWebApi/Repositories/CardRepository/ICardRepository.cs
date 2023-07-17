using KanbanWebApi.Dto;

namespace KanbanWebApi.Repositories.CardRepository
{
    public interface ICardRepository
    {
        Task<List<Card>> Get();
        Task<Card?> GetById(int id);
        Task<List<Card>?> Create(CreateCardDto request);
        Task<List<Card>?> Update(UpdateCardDto request);
        Task<List<Card>?> Delete(int id);
    }
}
