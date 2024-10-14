using System.Text.Json.Serialization;

namespace BibliotecaAPI.Models
{
    public class AutorModel
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }

        [JsonIgnore] // Anotação que indica que a propriedade não deve aparecer no input da API
        public ICollection<LivroModel>? Livros {get; set;}
    }
}