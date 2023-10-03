using Microsoft.AspNetCore.Mvc;
using NihonItarareApi.DTOs.Produto;
using NihonItarareApi.Models;
using NihonItarareApi.Services.Produtos;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Reflection.Metadata;

namespace NihonItarareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Produto>))]
        [Route("obter-produtos")]
        public IActionResult ObterProdutos()
        {
            try
            {
                var produtos = _produtoService.ObterProdutos();
                if (produtos == null)
                    return NotFound(produtos);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Produto))]
        [Route("obter-produto")]
        public IActionResult ObterProduto([FromHeader] int id)
        {
            try
            {
                var produto = _produtoService.ObterProdutoPorId(id);
                if (produto == null)
                    return NotFound(produto);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Produto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível inserir o produto")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("inserir-produto")]
        public IActionResult InserirProduto([FromBody] InInserirProduto input)
        {
            try
            {
                var produto = _produtoService.InserirProduto(input);
                if (produto != null)
                {
                    return Ok("Produto inserido com sucesso.");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível alterar o produto")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("alterar-produto")]
        public IActionResult AlterarProduto([FromBody] InAlterarProduto input)
        {
            try
            {
                bool sucess = _produtoService.AlterarProduto(input);
                if (sucess)
                {
                    return Ok("Produto editado com sucesso.");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("deletar-produto")]
        public IActionResult DeletarProduto([FromHeader] int id)
        {
            try
            {
                var excluir = _produtoService.DeletarProduto(id);
                if (excluir == true)
                    return Ok("Produto excluído com sucesso.");
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
