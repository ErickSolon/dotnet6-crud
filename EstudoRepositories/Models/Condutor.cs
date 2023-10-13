namespace EstudoRepositories.Models;
public class Condutor
{
    public long Id { get; set; }
    public string NomeCompleto { get; set; }
    public string CPF { get; set; }
    public Veiculos Veiculo { get; set; }
}
