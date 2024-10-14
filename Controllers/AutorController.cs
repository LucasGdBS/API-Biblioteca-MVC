using BibliotecaAPI.Dto.Autor;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services.Autor;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController(IAutorInterface autorInterface) : ControllerBase
    {
        private readonly IAutorInterface _autorInterface = autorInterface;

        [HttpGet("")]
        public async Task<IActionResult> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("{idAutor:guid}")]
        public async Task<IActionResult> BuscarAutorPorId(Guid idAutor)
        {
            try
            {
                var autor = await _autorInterface.BuscarAutorPorId(idAutor);
                return Ok(autor);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> AdicionarAutor(AutorDTO autor)
        {
            await _autorInterface.AdicionarAutor(autor);
            return Created("", autor);
        }

        [HttpPut("{idAutor:guid}")]
        public async Task<IActionResult> AtualizarAutor(Guid idAutor, AutorDTO autor)
        {
            try
            {
                var autorAtualizado = await _autorInterface.AtualizarAutor(idAutor, autor);
                return Ok(autorAtualizado);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("porLivro/{idLivro:guid}")]
        public async Task<IActionResult> BuscarAutorPorIdLivro(Guid idLivro)
        {
            try
            {
                var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
                return Ok(autor);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{idAutor:guid}")]
        public async Task<IActionResult> DeletarAutor(Guid idAutor)
        {
            try
            {
                var autor = await _autorInterface.DeletarAutor(idAutor);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}