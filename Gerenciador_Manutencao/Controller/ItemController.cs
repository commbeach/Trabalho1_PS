using Controle_Manutencao.Service;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_Manutencao.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterItem(int id)
        {
            var item = await _itemService.ObterItemPorId(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ItemResponseDTO>> CadastrarItem(ItemRequestDTO itemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = await _itemService.CadastrarItem(itemDTO);
            return CreatedAtAction(nameof(ObterItem), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirItem(int id)
        {
            await _itemService.ExcluirItem(id);
            return NoContent();
        }
    }
}
