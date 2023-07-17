using KanbanWebApi.Dto;
using KanbanWebApi.Repositories.CargoRepository;
using Microsoft.AspNetCore.Mvc;

namespace KanbanWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoRepository _CargoRepository;

        public CargoController(ICargoRepository CargoRepository)
        {
            _CargoRepository = CargoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cargo>>> Get()
        {
            return await _CargoRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetById(int id)
        {
            var result = await _CargoRepository.GetById(id);
            if (result == null)
                return NotFound("Cargo nao encontrado.");
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<List<Cargo>>> Create(CreateCargoDto request)
        {
            _ = await _CargoRepository.Create(request);
            return await Get();
        }

        [HttpPut]
        public async Task<ActionResult<Cargo>> Update(UpdateCargoDto request)
        {
            var result = await _CargoRepository.Update(request);
            if (result == null)
                return NotFound("Cargo nao encontrado.");
            return await GetById(request.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cargo>>> Delete(int id)
        {
            var result = await _CargoRepository.Delete(id);
            if (result == null)
                return NotFound("Cargo nao encontrado.");

            return await Get();
        }
    }
}
