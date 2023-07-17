using KanbanWebApi.Dto;

namespace KanbanWebApi.Repositories.ColaboradorRepository
{
    public interface IColaboradorRepository
    {
        Task<List<Colaborador>> Get();
        Task<Colaborador?> GetById(int id);
        Task<List<Colaborador>?> Create(CreateColaboradorDto request);
        Task<List<Colaborador>?> Update(UpdateColaboradorDto request);
        Task<List<Colaborador>?> Delete(int id);
    }
}
