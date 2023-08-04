using backend.Models;

namespace backend.Controllers
{
    public class BibliotecaDbContext
    {
        public List<Livros> LivrosModel {get; set;}

        public BibliotecaDbContext() {
            LivrosModel = new List<Livros>();
        }
    }
}