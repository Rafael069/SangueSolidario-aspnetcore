using MediatR;
using Microsoft.AspNetCore.Mvc;
using SangueSolidario.Application.Commands.Enderecos.DeleteEndereco;
using SangueSolidario.Application.Commands.Enderecos.UpdateEndereco;
using SangueSolidario.Application.Queries.Enderecos.GetAllEndereco;
using SangueSolidario.Application.Queries.Enderecos.GetByIdEndereco;


namespace SangueSolidario.API.Controllers
{
    [Route("api/enderecos")]
    public class EnderecosController : ControllerBase
    {

        private readonly IMediator _mediator;

        public EnderecosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Cadastro de endereço integrar API externa para consulta CEP. (PLUS)

        //Busca endereco

        [HttpGet("detalhes-enderecos/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {

            var queryByIdEndereco = new GetByIdEnderecoQuery(id);

            var endereco = await _mediator.Send(queryByIdEndereco);

            if (endereco == null)
            {
                return NotFound();
            }

            return Ok(endereco);
        }



        //Busca todos enderecos

        [HttpGet("all-doacoes")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllEnderecoQuery();

            var enderecos = await _mediator.Send(query);
            return Ok(enderecos);
        }

        


        //Atualizar enderecos

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateEnderecoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        //Deleta enderecos


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var command = new DeleteEnderecoCommand(id);

            await _mediator.Send(command);

            return NoContent();


        }

    }
}
