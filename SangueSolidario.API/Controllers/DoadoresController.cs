using MediatR;
using Microsoft.AspNetCore.Mvc;
using SangueSolidario.Application.Commands.Doadores.CreateDoador;
using SangueSolidario.Application.Commands.Doadores.DeleteDoador;
using SangueSolidario.Application.Commands.Doadores.UpdateDoador;
using SangueSolidario.Application.Queries.Doador.GetByIdDoador;
using SangueSolidario.Application.Queries.Doadores.GetAllDoador;


namespace SangueSolidario.API.Controllers
{
    [Route("api/doadores")]
    public class DoadoresController : ControllerBase
    {

        private readonly IMediator _mediator;

        public DoadoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Busca doador especifíco

        [HttpGet("detalhes-doadores/{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {

            var queryByIdDoador = new GetByIdDoadorQuery(id);

            var doador = await _mediator.Send(queryByIdDoador);

            if (doador == null)
            {
                return NotFound();
            }

            return Ok(doador);
        }


        //Busca todos doadores

        [HttpGet("all-doadores")]

        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDoadorQuery();

            var doadores = await _mediator.Send(query);

            return Ok(doadores);
        }

        //Cadastro de doadores


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDoadorCommand command)
        {
            // Validação

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna erros de vinculação
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);

        }


        //Atualizar doares

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDoadorCommand command)
        {

            await _mediator.Send(command);

            return NoContent();

        }


        //Deleta doares


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var command = new DeleteDoadorCommand(id);

            await _mediator.Send(command);

            return NoContent();


        }

    }
}
