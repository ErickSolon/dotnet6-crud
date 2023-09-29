using System.Text.Json.Serialization;

namespace EstudoRepositories.Models
{
    public class Condutor
    {
        public long Id { get; set; }
        public Veiculos Veiculo { get; set; }
    }
}
