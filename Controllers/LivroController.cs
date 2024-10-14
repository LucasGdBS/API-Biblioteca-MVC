using BibliotecaAPI.Dto.Livro;
using BibliotecaAPI.Services.Livro;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController(ILivroInterface livroInterface) : ControllerBase
    {

        private readonly ILivroInterface _livroInterface = livroInterface;

        [HttpGet("")]
        public async Task<IActionResult> ListarLivros()
        {
            return Ok(await _livroInterface.ListarLivros());
        }

        [HttpGet("{idLivro:guid}")]
        public async Task<IActionResult> BuscarLivroPorId(Guid idLivro)
        {
            try
            {
                return Ok(await _livroInterface.BuscarLivroPorId(idLivro));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> AdicionarLivro(LivroDTO livro)
        {
            await _livroInterface.AdicionarLivro(livro);
            return Created("", livro);
        }

        [HttpPut("{idLivro:guid}")]
        public async Task<IActionResult> AtualizarLivro(Guid idLivro, LivroDTO livro)
        {
            try
            {
                return Ok(await _livroInterface.AtualizarLivro(idLivro, livro));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("porAutor/{idAutor:guid}")]
        public async Task<IActionResult> BuscarLivroPorIdAutor(Guid idAutor)
        {
            try
            {
                return Ok(await _livroInterface.BuscarLivroPorIdAutor(idAutor));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{idLivro:guid}")]
        public async Task<IActionResult> DeletarLivro(Guid idLivro)
        {
            try
            {
                var livro = await _livroInterface.DeletarLivro(idLivro);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        
    }
}