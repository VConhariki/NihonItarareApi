using Microsoft.AspNetCore.Mvc;
using NihonItarareApi.DTOs.Mesa;
using NihonItarareApi.Models;
using NihonItarareApi.Services.Mesas;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace NihonItarareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaService _mesaService;

        public MesaController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Mesa>))]
        [Route("obter-mesas")]
        public IActionResult ObterMesas()
        {
            try
            {
                var mesas = _mesaService.ObterMesas();
                if (mesas == null)
                    return NotFound(mesas);
                return Ok(mesas);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Mesa))]
        [Route("obter-mesa")]
        public IActionResult ObterMesa([FromHeader] int id)
        {
            try
            {
                var mesa = _mesaService.ObterMesaPorId(id);
                if (mesa == null)
                    return NotFound(mesa);
                return Ok(mesa);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Mesa))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível inserir o mesa")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("inserir-mesa")]
        public IActionResult InserirMesa([FromBody] InInserirMesa input)
        {
            try
            {
                var mesa = _mesaService.InserirMesa(input);
                if (mesa != null)
                {
                    return Ok("Mesa inserida com sucesso.");
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
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(string), Description = "Não foi possível alterar o mesa")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string), Description = "Algo deu errado")]
        [Route("alterar-mesa")]
        public IActionResult AlterarMesa([FromBody] InAlterarMesa input)
        {
            try
            {
                bool sucess = _mesaService.AlterarMesa(input);
                if (sucess)
                {
                    return Ok("Mesa editada com sucesso.");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("deletar-mesa")]
        public IActionResult DeletarMesa([FromHeader] int id)
        {
            try
            {
                var excluir = _mesaService.DeletarMesa(id);
                if (excluir == true)
                    return Ok("Mesa excluído com sucesso.");
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
