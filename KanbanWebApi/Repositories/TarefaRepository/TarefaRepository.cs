using KanbanWebApi.Data;
using KanbanWebApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace KanbanWebApi.Repositories.TarefaRepository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DataContext _dataContext;

        public TarefaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Tarefa>> Get()
        {
            var tarefas = await _dataContext.Tarefa
             .Include(x => x.Cards)
             .ToListAsync();

            return await _dataContext.Tarefa.ToListAsync();
        }
        public async Task<Tarefa?> GetById(int id)
        {
            var tarefa = await _dataContext.Tarefa
             .Where(x => x.Id == id)
             .Include(x => x.Cards)
             .FirstOrDefaultAsync();

            return tarefa;
        }
        public async Task<List<Tarefa>?> Create(CreateTarefaDto request)
        {
            var novaTarefa = new Tarefa
            {
                Nome = request.Nome
            };

            _dataContext.Add(novaTarefa);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Tarefa.ToListAsync();
        }

        public async Task<List<Tarefa>?> Update(UpdateTarefaDto request)
        {
            var tarefa = await _dataContext.Tarefa.FindAsync(request.Id);
            if (tarefa is null)
            {
                return null;
            }

            tarefa.Nome = request.Nome;

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Tarefa.ToListAsync();
        }
        public async Task<List<Tarefa>?> Delete(int id)
        {
            var tarefa = await _dataContext.Tarefa.FindAsync(id);
            if (tarefa is null)
            {
                return null;
            }

            if (tarefa.Cards is not null)
            {
                return null;
            }

            _dataContext.Tarefa.Remove(tarefa);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Tarefa.ToListAsync();
        }
    }
}
