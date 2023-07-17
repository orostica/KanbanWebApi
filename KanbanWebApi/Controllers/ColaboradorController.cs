using KanbanWebApi.Dto;
using KanbanWebApi.Repositories.ColaboradorRepository;
using Microsoft.AspNetCore.Mvc;

namespace KanbanWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Colaborador>>> Get()
        {
            return await _colaboradorRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> GetById(int id)
        {
            var result = await _colaboradorRepository.GetById(id);
            if (result == null)
                return NotFound("Colaborador nao encontrado.");
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<List<Colaborador>>> Create(CreateColaboradorDto request)
        {
            var result = await _colaboradorRepository.Create(request);
            if (result == null) 
                return NotFound("Cargo nao encontrado.");

            return await Get();
        }

        [HttpPut]
        public async Task<ActionResult<Colaborador>> Update(UpdateColaboradorDto request)
        {
            var result = await _colaboradorRepository.Update(request);
            if (result == null)
                return NotFound("Colaborador nao encontrado.");
            return await GetById(request.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Colaborador>>> Delete(int id)
        {
            var result = await _colaboradorRepository.Delete(id);
            if (result == null)
                return NotFound("Colaborador nao encontrado.");

            return await Get();
        }

    }
}
