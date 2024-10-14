namespace BibliotecaAPI.Models
{
    public class LivroModel
    {

        public Guid Id {get; init;} = Guid.NewGuid();

        public string? Titulo {get; set;}

        public AutorModel? Autor {get; set;}
        
    }
}