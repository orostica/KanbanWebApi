using KanbanWebApi.Data;
using KanbanWebApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace KanbanWebApi.Repositories.CargoRepository
{
    public class CargoRepository : ICargoRepository
    {
        private readonly DataContext _dataContext;

        public CargoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Cargo>> Get()
        {
            var cargos = await _dataContext.Cargo
            .ToListAsync();

            return cargos;
        }
        public async Task<Cargo?> GetById(int id)
        {
            var cargo = await _dataContext.Cargo
             .Where(x => x.Id == id)
             .FirstOrDefaultAsync();

            return cargo;
        }
        public async Task<List<Cargo>?> Create(CreateCargoDto cargo)
        {
            var novoCargo = new Cargo
            {
                Nome = cargo.Nome,
                Situacao = true,
                Descricao = cargo.Descricao,
            };

            _dataContext.Add(novoCargo);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Cargo.ToListAsync();
        }
        public async Task<List<Cargo>?> Update(UpdateCargoDto request)
        {

            var cargo = await _dataContext.Cargo.FindAsync(request.Id);
            if (cargo == null)
            {
                return null;
            }

            cargo.Nome = request.Nome;
            cargo.Descricao = request.Descricao;
            cargo.Situacao = request.Situacao;

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Cargo.ToListAsync();
        }
        public async Task<List<Cargo>?> Delete(int id)
        {
            var cargo = await _dataContext.Cargo.FindAsync(id);
            if (cargo is null)
            {
                return null;
            }

            _dataContext.Cargo.Remove(cargo);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Cargo.ToListAsync();
        }
    }
}
