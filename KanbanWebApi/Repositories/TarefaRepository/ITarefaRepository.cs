using KanbanWebApi.Dto;

namespace KanbanWebApi.Repositories.TarefaRepository
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> Get();
        Task<Tarefa?> GetById(int id);
        Task<List<Tarefa>?> Create(CreateTarefaDto request);
        Task<List<Tarefa>?> Update(UpdateTarefaDto request);
        Task<List<Tarefa>?> Delete(int id);
    }
}
