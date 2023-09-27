using Microsoft.AspNetCore.Mvc;
using NihonItarareApi.DTOs.Pedido;
using NihonItarareApi.Models;
using NihonItarareApi.Services.Pedidos;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace NihonItarareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Pedido>))]
        [Route("obter-pedidos")]
        public IActionResult ObterPedidos()
        {
            try
            {
                var pedidos = _pedidoService.ObterPedidos();
                if (pedidos == null)
                    return NotFound(pedidos);
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Pedido))]
        [Route("obter-pedido")]
        public IActionResult ObterPedido([FromHeader] int id)
        {
            try
            {
                var pedido = _pedidoService.ObterPedidoPorId(id);
                if (pedido == null)
                    return NotFound(pedido);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Pedido))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível inserir o Pedido")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("inserir-pedido")]
        public IActionResult InserirPedido([FromBody] InInserirPedido input)
        {
            try
            {
                var pedido = _pedidoService.InserirPedido(input);
                if (pedido != null)
                {
                    return Ok("Pedido inserido com sucesso.");
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
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível alterar o Pedido")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("alterar-pedido")]
        public IActionResult AlterarPedido([FromBody] InAlterarPedido input)
        {
            try
            {
                bool sucess = _pedidoService.AlterarPedido(input);
                if (sucess)
                {
                    return Ok("Pedido editado com sucesso.");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("deletar-pedido")]
        public IActionResult DeletarPedido([FromHeader] int id)
        {
            try
            {
                var excluir = _pedidoService.DeletarPedido(id);
                if (excluir == true)
                    return Ok("Pedido excluído com sucesso.");
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
