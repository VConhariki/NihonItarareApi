using Microsoft.AspNetCore.Mvc;
using NihonItarareApi.DTOs.Item;
using NihonItarareApi.Models;
using NihonItarareApi.Services.Itens;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;


namespace NihonItarareApi.Controllers
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

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Item>))]
        [Route("obter-itens")]
        public IActionResult ObterItens()
        {
            try
            {
                var itens = _itemService.ObterItens();
                if (itens == null)
                    return NotFound(itens);
                return Ok(itens);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Item))]
        [Route("obter-item")]
        public IActionResult ObterItem([FromHeader] int id)
        {
            try
            {
                var item = _itemService.ObterItemPorId(id);
                if (item == null)
                    return NotFound(item);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Item))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível inserir o Item")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("inserir-item")]
        public IActionResult InserirItem([FromBody] InInserirItem input)
        {
            try
            {
                var item = _itemService.InserirItem(input);
                if (item != null)
                {
                    return Ok("Item inserido com sucesso.");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível alterar o Item")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("alterar-item")]
        public IActionResult AlterarItem([FromBody] InAlterarItem input)
        {
            try
            {
                bool sucess = _itemService.AlterarItem(input);
                if (sucess)
                {
                    return Ok("Item editado com sucesso.");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("deletar-item")]
        public IActionResult DeletarItem([FromHeader] int id)
        {
            try
            {
                var excluir = _itemService.DeletarItem(id);
                if (excluir == true)
                    return Ok("Item excluído com sucesso.");
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
