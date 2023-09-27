using Microsoft.AspNetCore.Mvc;
using NihonItarareApi.DTOs.ItemPedido;
using NihonItarareApi.Models;
using NihonItarareApi.Services.ItensPedidos;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace NihonItarareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoService _itemPedidoService;

        public ItemPedidoController(IItemPedidoService itemProdutoService)
        {
            _itemPedidoService = itemProdutoService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ItemPedido>))]
        [Route("obter-itensPedidosPedidos")]
        public IActionResult ObterItensPedidos()
        {
            try
            {
                var itensPedidos = _itemPedidoService.ObterItensPedidos();
                if (itensPedidos == null)
                    return NotFound(itensPedidos);
                return Ok(itensPedidos);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ItemPedido))]
        [Route("obter-itemPedido")]
        public IActionResult ObterItemPedido([FromHeader] int id)
        {
            try
            {
                var itemPedido = _itemPedidoService.ObterItemPedidoPorId(id);
                if (itemPedido == null)
                    return NotFound(itemPedido);
                return Ok(itemPedido);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ItemPedido))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível inserir o ItemPedido")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("inserir-itemPedido")]
        public IActionResult InserirItemPedido([FromBody] InInserirItemPedido input)
        {
            try
            {
                var itemPedido = _itemPedidoService.InserirItemPedido(input);
                if (itemPedido != null)
                {
                    return Ok("ItemPedido inserido com sucesso.");
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
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível alterar o ItemPedido")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("alterar-itemPedido")]
        public IActionResult AlterarItemPedido([FromBody] InAlterarItemPedido input)
        {
            try
            {
                bool sucess = _itemPedidoService.AlterarItemPedido(input);
                if (sucess)
                {
                    return Ok("ItemPedido editado com sucesso.");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("deletar-itemPedido")]
        public IActionResult DeletarItemPedido([FromHeader] int id)
        {
            try
            {
                var excluir = _itemPedidoService.DeletarItemPedido(id);
                if (excluir == true)
                    return Ok("ItemPedido excluído com sucesso.");
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
