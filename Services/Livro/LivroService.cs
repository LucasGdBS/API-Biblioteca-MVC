using BibliotecaAPI.Data;
using BibliotecaAPI.Dto.Livro;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Services.Livro
{
    public class LivroService(AppDbContext context) : ILivroInterface
    {
        private readonly AppDbContext _context = context;
        public async Task<LivroModel> AdicionarLivro(LivroDTO livro)
        {
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == livro.AutorId)
                ?? throw new Exception("Autor não encontrado");

                var livroModel = new LivroModel{ Titulo = livro.Titulo, Autor = autor };
                _context.Livros.Add(livroModel);
                await _context.SaveChangesAsync();
                return livroModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LivroModel> AtualizarLivro(Guid idLivro, LivroDTO livro)
        {
            try
            {
                var livroAtual = await _context.Livros
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(l => l.Id == idLivro)
                ?? throw new Exception("Livro não encontrado");

                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == livro.AutorId)
                ?? throw new Exception("Autor não encontrado");


                livroAtual.Titulo = livro.Titulo;
                livroAtual.Autor = autor;

                await _context.SaveChangesAsync();
                return livroAtual;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LivroModel> BuscarLivroPorId(Guid idLivro)
        {
            try
            {
                var livro = await _context.Livros
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(l => l.Id == idLivro)
                ?? throw new Exception("Livro não encontrado");

                return livro;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<LivroModel>> BuscarLivroPorIdAutor(Guid idAutor)
        {
            try
            {
                var livros = await _context.Livros
                            .Include(l => l.Autor)
                            .Where(l => l.Autor.Id == idAutor)
                            .ToListAsync()
                            ?? throw new Exception("Livro não encontrado");
                
                return livros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LivroModel> DeletarLivro(Guid idLivro)
        {
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == idLivro)
                ?? throw new Exception("Livro não encontrado");

                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();

                return livro;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<LivroModel>> ListarLivros()
        {
            try
            {
                return await _context.Livros
                .Include(l => l.Autor)
                .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}