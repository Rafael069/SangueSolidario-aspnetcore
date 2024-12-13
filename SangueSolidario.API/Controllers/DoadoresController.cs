using Microsoft.AspNetCore.Mvc;
using SangueSolidario.Application.InputModels;
using SangueSolidario.Application.Services.Implementations;
using SangueSolidario.Application.Services.Interfaces;

namespace SangueSolidario.API.Controllers
{
    [Route("api/doadores")]
    public class DoadoresController : ControllerBase
    {

        private readonly IDoadorService _doadorService;

        public DoadoresController(IDoadorService doadorService)
        {
            _doadorService = doadorService;
        }

        //Busca doador especifíco

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            var doador = _doadorService.GetById(id);

            if (doador == null)
            {
                return NotFound();
            }

            return Ok(doador);
        }


        //Busca todos doadores
        [HttpGet]
        [Route("all")]
        
        public IActionResult GetAll()
        {
            var doadores = _doadorService.GetAll();
            return Ok(doadores);
        }

        //Cadastro de doadores


        [HttpPost]
        public IActionResult Post([FromBody] NewDoadorInputModel inputModel)
        {
            // Validação

            //

            var id = _doadorService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

        }


        //Atualizar doares


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateDoadorInputModel inputModel)
        {
            // Validações
            //if (updateLivro.descricao.lengh > 50)
            //{
            //    return BadRequest();
            //}
            _doadorService.Update(inputModel);

            return NoContent();

        }

        //Deleta doares

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _doadorService.Delete(id);

            return NoContent(); // Retorna 204 (sem conteúdo) após a exclusão bem-sucedida


        }


    }
}
