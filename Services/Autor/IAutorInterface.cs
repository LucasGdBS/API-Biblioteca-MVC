using BibliotecaAPI.Models;
using BibliotecaAPI.Dto.Autor;

namespace BibliotecaAPI.Services.Autor
{
    public interface IAutorInterface
    {
        Task<List<AutorModel>> ListarAutores();
        Task<AutorModel> BuscarAutorPorId(Guid idAutor);
        Task<AutorModel> BuscarAutorPorIdLivro(Guid idLivro);
        Task<AutorModel> AdicionarAutor(AutorDTO autor);
        Task<AutorModel> AtualizarAutor(Guid idAutor, AutorDTO autor);
        Task<AutorModel> DeletarAutor(Guid idAutor);
        
    }
}