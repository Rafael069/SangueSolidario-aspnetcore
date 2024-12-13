using Microsoft.AspNetCore.Mvc;
using SangueSolidario.Application.InputModels;
using SangueSolidario.Application.Services.Implementations;
using SangueSolidario.Application.Services.Interfaces;
using System.Runtime.ConstrainedExecution;

namespace SangueSolidario.API.Controllers
{
    [Route("api/enderecos")]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecosController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        //Cadastro de endereço integrar API externa para consulta CEP. (PLUS)

        //Busca endereco

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var endereco = _enderecoService.GetById(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return Ok(endereco);
        }

        //Busca todos enderecos

        [HttpGet]
        [Route("all")]
        
        public IActionResult GetAll()
        {
            var enderecos = _enderecoService.GetAll();
            return Ok(enderecos);
        }


        //Cadastro de enderecos


        [HttpPost]
        public IActionResult Post([FromBody] NewEnderecoInputModel inputModel)
        {
            // Validação

            //

            var id = _enderecoService.Create(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

        }


        //Atualizar enderecos


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateEnderecoInputModel inputModel)
        {
            // Validações

            //
            _enderecoService.Update(inputModel);
            return NoContent();
        }

        //Deleta enderecos

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _enderecoService.Delete(id);

            return NoContent(); // Retorna 204 (sem conteúdo) após a exclusão bem-sucedida
        }

    }
}
