using MediatR;
using Microsoft.AspNetCore.Mvc;
using SangueSolidario.Application.Commands.EstoquesDeSangue.CreateEstoquesDeSangue;
using SangueSolidario.Application.Commands.EstoquesDeSangue.DeleteEstoquesDeSangue;
using SangueSolidario.Application.Commands.EstoquesDeSangue.UpdateEstoquesDeSangue;
using SangueSolidario.Application.Queries.EstoquesDeSangue.GetAllEstoqueDeSangue;
using SangueSolidario.Application.Queries.EstoquesDeSangue.GetByIdEstoqueDeSangue;
using SangueSolidario.Application.Queries.EstoquesDeSangue.GetEstoquesCriticos;
using SangueSolidario.Application.Queries.EstoquesDeSangue.GetRelQtdPorTipo;


namespace SangueSolidario.API.Controllers
{
    [Route("api/estoquesDeSangue")]
    public class EstoquesDeSangueController : ControllerBase
    {

        //private readonly IEstoqueDeSangueService _estoqueDeSangueService;

        private readonly IMediator _mediator;

        public EstoquesDeSangueController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //Busca estoque em si

        [HttpGet("detalhes-estoque/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var queryByIdEstoqueDeSangue = new GetByIdEstoqueDeSangueQuery(id);

            var estoqueDeSangue = await _mediator.Send(queryByIdEstoqueDeSangue);

            if (estoqueDeSangue == null)
            {
                return NotFound();
            }

            return Ok(estoqueDeSangue);
        }



        //Busca estoques

        [HttpGet("all-estoque")]

        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllEstoqueDeSangueQuery();

            var estoquesDeSangue = await _mediator.Send(query);

            return Ok(estoquesDeSangue);
        }


        //Cadastro de estoques


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEstoquesDeSangueCommand command)
        {

            // Validação

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna erros de vinculação
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        //Atualizar estoques

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateEstoquesDeSangueCommand command)
        {
            await _mediator.Send(command);

            return NoContent();

        }


        //Deleta estoques

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {

            var command = new DeleteEstoquesDeSangueCommand(id);

            await _mediator.Send(command);

            return NoContent();

        }

        // Relatório de Estoque de Sangue por Tipo
        //[HttpGet]
        //[Route("relatorio/estoque")]
        //public IActionResult RelatorioEstoquePorTipo()
        //{
        //    var relatorio = _estoqueDeSangueService.GerarRelatorioQuantidadePorTipo();
        //    //var relatorio = _estoqueDeSangueService.();
        //    return Ok(relatorio);
        //}

        [HttpGet("relatorio/estoque")]
        public async Task<IActionResult> RelatorioEstoquePorTipo()
        {
            var queryRelatorio = new GetRelQtdPorTipoQuery();

            var relatorio = await _mediator.Send(queryRelatorio);

            return Ok(relatorio);

        }

        // Monitoramento de quantidade Mínima

        //[HttpGet("criticos")]
        //public IActionResult GetEstoquesCriticos()
        //{
        //    var estoquesCriticos = _estoqueDeSangueService.VerificarEstoquesCriticos();

        //    if (!estoquesCriticos.Any())
        //        return Ok("Nenhum estoque abaixo do mínimo no momento.");

        //    return Ok(estoquesCriticos);
        //}



        [HttpGet("criticos")]
        public async Task<IActionResult> GetEstoquesCriticos()
        {
            var queryCriticos = new GetEstoquesCriticosQuery();

            var estoquesCriticos = await _mediator.Send(queryCriticos);

            if (!estoquesCriticos.Any())
                return Ok("Nenhum estoque abaixo do mínimo no momento.");

            return Ok(estoquesCriticos);

        }

    }
}
