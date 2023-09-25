using Microsoft.AspNetCore.Mvc;
using NihonItarareApi.DTOs.Estoque;
using NihonItarareApi.Models;
using NihonItarareApi.Services.Estoques;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace NihonItarareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Estoque>))]
        [Route("obter-estoques")]
        public IActionResult ObterEstoques()
        {
            try
            {
                var estoques = _estoqueService.ObterEstoques();
                if (estoques == null)
                    return NotFound(estoques);
                return Ok(estoques);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Estoque))]
        [Route("obter-estoque")]
        public IActionResult ObterEstoque([FromHeader] int id)
        {
            try
            {
                var estoque = _estoqueService.ObterEstoquePorId(id);
                if (estoque == null)
                    return NotFound(estoque);
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Estoque))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível inserir o estoque")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("inserir-estoque")]
        public IActionResult InserirEstoque([FromBody] InInserirEstoque input)
        {
            try
            {
                var estoque = _estoqueService.InserirEstoque(input);
                if (estoque != null)
                {
                    return Ok("Estoque inserido com sucesso.");
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
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível alterar o estoque")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("alterar-estoque")]
        public IActionResult AlterarEstoque([FromBody] InAlterarEstoqueQuantidade input)
        {
            try
            {
                bool sucess = _estoqueService.AlterarEstoque(input);
                if (sucess)
                {
                    return Ok("Estoque editado com sucesso.");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("deletar-estoque")]
        public IActionResult DeletarEstoque([FromHeader] int id)
        {
            try
            {
                var excluir = _estoqueService.DeletarEstoque(id);
                if (excluir == true)
                    return Ok("Estoque excluído com sucesso.");
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
