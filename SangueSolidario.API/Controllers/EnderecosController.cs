using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace SangueSolidario.API.Controllers
{
    [Route("api/enderecos")]
    public class EnderecosController : ControllerBase
    {
        //Cadastrar

        //Cadastro de endereço integrar API externa para consulta CEP. (PLUS)

        //Busca doador

        [HttpGet("{id}")]
        public IActionResult GetById()
        {
            return Ok();
        }

        [HttpGet]
        [Route("all")]
        //Busca todos doadores
        public IActionResult GetAll()
        {
            return Ok();
        }


        //Cadastro de doadores


        [HttpPost]
        public IActionResult Post(/*[FromBody] CreaLivroModel createDoador*/)
        {
            // Validação
            //if (createLivro.titulo > 50)
            //{
            //    return BadRequest();
            //}
            //return CreateAtAction(nameof(GetById), new { id = createLivro.id }, createLivro);
            return Ok();
        }


        //Atualizar doares


        [HttpPut("{id}")]
        public IActionResult Put(/*int id, [FromBody] UpdateLivroModel updateLivro*/)
        {
            // Validações
            //if (updateLivro.descricao.lengh > 50)
            //{
            //    return BadRequest();
            //}

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Lógica para verificar se o doador existe
            //var doador = Ok();/* Aqui você pode fazer a busca do doador, por exemplo, doadorService.GetById(id) */

            //if (doador == null)
            //{
            //    return NotFound(); // Retorna 404 se o doador não for encontrado
            //}

            // Lógica para excluir o doador, por exemplo:
            // doadorService.Delete(id);

            return NoContent(); // Retorna 204 (sem conteúdo) após a exclusão bem-sucedida
        }

    }
}
