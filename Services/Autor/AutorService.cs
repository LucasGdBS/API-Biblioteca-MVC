using BibliotecaAPI.Data;
using BibliotecaAPI.Dto.Autor;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Services.Autor
{
    public class AutorService(AppDbContext context) : IAutorInterface
    {
        private readonly AppDbContext _context = context;

        public async Task<AutorModel> AdicionarAutor(AutorDTO autor)
        {
            try
            {
                var autorModel = new AutorModel{ Nome = autor.Nome, Sobrenome = autor.Sobrenome };
                await _context.Autores.AddAsync(autorModel);
                await _context.SaveChangesAsync();
                return autorModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AutorModel> AtualizarAutor(Guid idAutor, AutorDTO autor)
        {
            try
            {
                var autorAtual = await _context.Autores.FirstOrDefaultAsync(a => a.Id == idAutor)
                ?? throw new Exception("Autor não encontrado");

                autorAtual.Nome = autor.Nome;
                autorAtual.Sobrenome = autor.Sobrenome;

                await _context.SaveChangesAsync();
                return autorAtual;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AutorModel> BuscarAutorPorId(Guid idAutor)
        {
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == idAutor)
                ?? throw new Exception("Autor não encontrado");

                return autor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AutorModel> BuscarAutorPorIdLivro(Guid idLivro)
        {
            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(l => l.Id == idLivro)
                    ?? throw new Exception("Livro não encontrado");

                return livro.Autor;
            }
            catch (Exception e)
            {   
                throw new Exception(e.Message);
            }
        }

        public async Task<AutorModel> DeletarAutor(Guid idAutor)
        {
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == idAutor)
                ?? throw new Exception("Autor não encontrado");

                _context.Autores.Remove(autor);

                await _context.SaveChangesAsync();
                return autor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<AutorModel>> ListarAutores()
        {
            try
            {
                var autores = await _context.Autores.ToListAsync();
                return autores;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}