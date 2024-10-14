using BibliotecaAPI.Dto.Livro;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services.Livro
{
    public interface ILivroInterface
    {
        public Task<List<LivroModel>> ListarLivros();
        public Task<LivroModel> BuscarLivroPorId(Guid idLivro);
        public Task<List<LivroModel>> BuscarLivroPorIdAutor(Guid idAutor);
        public Task<LivroModel> AdicionarLivro(LivroDTO livro);
        public Task<LivroModel> AtualizarLivro(Guid idLivro, LivroDTO livro);
        public Task<LivroModel> DeletarLivro(Guid idLivro);

    }
}