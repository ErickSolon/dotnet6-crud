using Microsoft.EntityFrameworkCore;

namespace EstudoRepositories.Models
{
    public class Veiculos
    {
        public long Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
    }
}
