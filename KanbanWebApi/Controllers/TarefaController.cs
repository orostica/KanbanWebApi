using KanbanWebApi.Dto;
using KanbanWebApi.Repositories.TarefaRepository;
using Microsoft.AspNetCore.Mvc;

namespace KanbanWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _TarefaRepository;

        public TarefaController(ITarefaRepository TarefaRepository)
        {
            _TarefaRepository = TarefaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> Get()
        {
            return await _TarefaRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetById(int id)
        {
            var result = await _TarefaRepository.GetById(id);
            if (result == null)
                return NotFound("Tarefa nao encontrado.");
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<List<Tarefa>>> Create(CreateTarefaDto request)
        {
            var result = await _TarefaRepository.Create(request);
            return await Get();
        }

        [HttpPut]
        public async Task<ActionResult<Tarefa>> Update(UpdateTarefaDto request)
        {
            var result = await _TarefaRepository.Update(request);
            if (result == null)
                return NotFound("Tarefa nao encontrado.");
            return await GetById(request.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Tarefa>>> Delete(int id)
        {
            var result = await _TarefaRepository.Delete(id);
            if (result == null)
                return NotFound("Nao foi possivel excluir");

            return await Get();
        }
    }
}
