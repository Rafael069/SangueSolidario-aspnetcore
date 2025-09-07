using Microsoft.AspNetCore.Mvc;
using SangueSolidario.Application.InputModels;
using SangueSolidario.Application.Services.Implementations;
using SangueSolidario.Application.Services.Interfaces;

namespace SangueSolidario.API.Controllers
{
    [Route("api/estoquesDeSangue")]
    public class EstoquesDeSangueController : ControllerBase
    {

        private readonly IEstoqueDeSangueService _estoqueDeSangueService;

        public EstoquesDeSangueController(IEstoqueDeSangueService estoqueDeSangueService)
        {
            _estoqueDeSangueService = estoqueDeSangueService;
        }


        //Busca estoque em si

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var estoqueDeSangue = _estoqueDeSangueService.GetById(id);

            if (estoqueDeSangue == null)
            {
                return NotFound();
            }

            return Ok(estoqueDeSangue);
        }

        //Busca estoques

        [HttpGet]
        [Route("all")]
        
        public IActionResult GetAll()
        {
            var estoquesDeSangue = _estoqueDeSangueService.GetAll();
            return Ok(estoquesDeSangue);
        }


        //Cadastro de estoques

        [HttpPost]
        public IActionResult Post([FromBody] NewEstoqueDeSangueInputModel inputModel)
        {
            // Validação

            //


            var id = _estoqueDeSangueService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }


        //Atualizar estoques

        [HttpPut("{id}")]
        public IActionResult Put(Doador doador, int quantidadeML)
        {
            // Validações

            //
            //Doador doador, int quantidadeML
            //_estoqueDeSangueService.Update(inputModel);
            _estoqueDeSangueService.UpdateEstoque(doador, quantidadeML);

            return NoContent();

        }


        //Deleta estoques

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _estoqueDeSangueService.Delete(id);

            return NoContent(); // Retorna 204 (sem conteúdo) após a exclusão bem-sucedida


        }


        // Relatório de Estoque de Sangue por Tipo
        [HttpGet]
        [Route("relatorio/estoque")]
        public IActionResult RelatorioEstoquePorTipo()
        {
            var relatorio = _estoqueDeSangueService.GerarRelatorioQuantidadePorTipo();
            //var relatorio = _estoqueDeSangueService.();
            return Ok(relatorio);
        }

        // Monitoramento de quantidade Mínima

        [HttpGet("criticos")]
        public IActionResult GetEstoquesCriticos()
        {
            var estoquesCriticos = _estoqueDeSangueService.VerificarEstoquesCriticos();

            if (!estoquesCriticos.Any())
                return Ok("Nenhum estoque abaixo do mínimo no momento.");

            return Ok(estoquesCriticos);
        }


    }
}
