using MediatR;
using Microsoft.AspNetCore.Mvc;
using SangueSolidario.Application.Commands.Doacaoes.CreateDoacao;
using SangueSolidario.Application.Commands.Doacaoes.DeleteDoacao;
using SangueSolidario.Application.Commands.Doacaoes.UpdateDoacao;
using SangueSolidario.Application.Queries.Doacoes.GeAllDoacao;
using SangueSolidario.Application.Queries.Doacoes.GetByIdDoacao;
using SangueSolidario.Application.Queries.Doacoes.GetRelatorioDoacoesUltimos30Dias;


namespace SangueSolidario.API.Controllers
{
    [Route("api/doacoes")]
    public class DoacoesController : ControllerBase
    {

        
        private readonly IMediator _mediator;

        public DoacoesController(IMediator mediator)
        {           
            _mediator = mediator;
        }

        //Busca doacao

        [HttpGet("detalhes-doacoes/{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            var queryByIdDoadordoacao = new GetByIdDoacaoQuery(id);

            var doacao = await _mediator.Send(queryByIdDoadordoacao);

            if (doacao == null)
            {
                return NotFound();
            }

            return Ok(doacao);
        }


        //Busca todas doacoes
       

        [HttpGet("all-doacoes")]

        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDoacaoQuery();

            var doacoes = await _mediator.Send(query);

            return Ok(doacoes);
        }




        //Cadastro de doacoes

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] CreateDoacaoCommand command)
        {
            // Validação

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna erros de vinculação
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);

        }



        //Atualizar doacoes


        [HttpPut("{id:int}")]

        public async Task<IActionResult> Put(int id, [FromBody] UpdateDoacaoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }


        //Deleta docacoes

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDoacaoCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }


        // Relatório de Doações nos Últimos 30 Dias

        [HttpGet]
        [Route("relatorio/doacoes-ultimos-30-dias")]
        public async Task<IActionResult> RelatorioDoacoesUltimos30Dias()
        {
            var query = new GetRelatorioDoacao30DiasQuery();

            var relatorio = await _mediator.Send(query);

            return Ok(relatorio);
        }

    }
}
