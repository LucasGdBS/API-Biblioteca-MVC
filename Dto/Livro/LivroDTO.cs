using BibliotecaAPI.Models;

namespace BibliotecaAPI.Dto.Livro
{
    public class LivroDTO
    {
        public required string Titulo {get; set;}

        public required Guid AutorId {get; set;}
    }
}