using KanbanWebApi.Data;
using KanbanWebApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace KanbanWebApi.Repositories.ColaboradorRepository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly DataContext _dataContext;

        public ColaboradorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Colaborador>> Get()
        {
            var colaboradores = await _dataContext.Colaborador
             .Include(x => x.Cargo)
             .ToListAsync();

            return await _dataContext.Colaborador.ToListAsync();
        }
        public async Task<Colaborador?> GetById(int id)
        {
            var colaborador = await _dataContext.Colaborador
             .Where(x => x.Id == id)
             .Include(x => x.Cargo)
             .FirstOrDefaultAsync();

            return colaborador;
        }
        public async Task<List<Colaborador>?> Create(CreateColaboradorDto request)
        {
            var cargo = await _dataContext.Cargo.FindAsync(request.CargoId);
            if (cargo == null)
            {
                return null;
            }

            var novoColaborador = new Colaborador
            {
                Nome = request.Nome,
                Situacao = true,
                Linkedin = request.Linkedin,
                Cargo = cargo,
            };

            _dataContext.Add(novoColaborador);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Colaborador.ToListAsync();
        }

        public async Task<List<Colaborador>?> Update(UpdateColaboradorDto request)
        {
            var colaborador = await _dataContext.Colaborador.FindAsync(request.Id);
            if (colaborador is null)
            {
                return null;
            }

            var cargo = await _dataContext.Cargo.FindAsync(request.CargoId);
            if (cargo == null)
            {
                return null;
            }

            colaborador.Nome = request.Nome;
            colaborador.Situacao = request.Situacao;
            colaborador.Linkedin = request.Linkedin;
            colaborador.CargoId = request.CargoId;
            colaborador.Cargo = cargo;

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Colaborador.ToListAsync();
        }
        public async Task<List<Colaborador>?> Delete(int id)
        {
            var colaborador = await _dataContext.Colaborador.FindAsync(id);
            if (colaborador is null)
            {
                return null;
            }

            _dataContext.Colaborador.Remove(colaborador);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Colaborador.ToListAsync();
        }
    }
}
