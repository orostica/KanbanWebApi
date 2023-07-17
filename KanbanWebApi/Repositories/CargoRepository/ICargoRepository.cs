using KanbanWebApi.Dto;

namespace KanbanWebApi.Repositories.CargoRepository
{
    public interface ICargoRepository
    {
        Task<List<Cargo>> Get();
        Task<Cargo?> GetById(int id);
        Task<List<Cargo>?> Create(CreateCargoDto request);
        Task<List<Cargo>?> Update(UpdateCargoDto request);
        Task<List<Cargo>?> Delete(int id);
    }
}
