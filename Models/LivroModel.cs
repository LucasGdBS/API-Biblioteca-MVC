namespace BibliotecaAPI.Models
{
    public class LivroModel
    {

        public Guid Id {get; init;} = Guid.NewGuid();

        public required string Titulo {get; set;}

        public required AutorModel Autor {get; set;}
        
    }
}