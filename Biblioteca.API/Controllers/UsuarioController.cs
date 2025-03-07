using Biblioteca.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarUsuarioModel criarLivro)
        {
            if (criarLivro.Titulo.Length > 50)
            {
                return BadRequest();
            }

            // Cadastrar o projeto

            return CreatedAtAction(nameof(GetById), new { }, criarLivro);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Buscar, se não existir, retorna NotFound

            // Remover 

            return NoContent();
        }
    }
}
