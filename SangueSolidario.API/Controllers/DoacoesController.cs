using Microsoft.AspNetCore.Mvc;
using SangueSolidario.Application.InputModels;
using SangueSolidario.Application.Services.Implementations;
using SangueSolidario.Application.Services.Interfaces;

namespace SangueSolidario.API.Controllers
{
    [Route("api/doacoes")]
    public class DoacoesController : ControllerBase
    {

        private readonly IDoacaoService _doacaoService;

        public DoacoesController(IDoacaoService doacaoService)
        {
            _doacaoService = doacaoService;
        }

        //Busca doacao

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var doacao = _doacaoService.GetById(id);

            if (doacao == null)
            {
                return NotFound();
            }

            return Ok(doacao);
        }



        //Busca todas doacoes
        [HttpGet]
        [Route("all")]

        public IActionResult GetAll()
        {

            var doacoes = _doacaoService.GetAll();
            return Ok(doacoes);
        }



        //Cadastro de doacoes

        [HttpPost]
        public IActionResult Post([FromBody] NewDoacaoInputModel inputModel)
        {
            // Validação

            //

            var id = _doacaoService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }


        //Atualizar doacoes

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateDoacaoInputModel inputModel)
        {
            // Validações
            //if (updateLivro.descricao.lengh > 50)
            //{
            //    return BadRequest();
            //}

            _doacaoService.Update(inputModel);

            return NoContent();
        }

        //Deleta docacoes

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _doacaoService.Delete(id);

            return NoContent(); // Retorna 204 (sem conteúdo) após a exclusão bem-sucedida
        }


    }
}
