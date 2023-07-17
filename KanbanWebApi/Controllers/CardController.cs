using KanbanWebApi.Dto;
using KanbanWebApi.Repositories.CardRepository;
 using Microsoft.AspNetCore.Mvc;

namespace KanbanWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;

        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Card>>> Get()
        {
            return await _cardRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetById(int id)
        {
            var result = await _cardRepository.GetById(id);
            if (result == null)
                return NotFound("Card nao encontrado.");
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<List<Card>>> Create(CreateCardDto request)
        {
            var result = await _cardRepository.Create(request);
            if (result == null) 
                return NotFound("Tarefa nao encontrada!");
    
            return await Get();
        }

        [HttpPut]
        public async Task<ActionResult<Card>> Update(UpdateCardDto request)
        {
            var result = await _cardRepository.Update(request);
            if (result == null)
                return NotFound("Card nao encontrado.");
            return await GetById(request.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Card>>> Delete(int id)
        {
            var result = await _cardRepository.Delete(id);
            if (result == null)
                return NotFound("Card nao encontrado.");

            return await Get();
        }
    }
}
