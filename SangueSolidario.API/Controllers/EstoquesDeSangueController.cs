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
        public IActionResult Put(int id, [FromBody] UpdateEstoqueDeSangueInputModel inputModel)
        {
            // Validações

            //

            _estoqueDeSangueService.Update(inputModel);

            return NoContent();

        }


        //Deleta estoques

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _estoqueDeSangueService.Delete(id);

            return NoContent(); // Retorna 204 (sem conteúdo) após a exclusão bem-sucedida


        }

    }
}
