using System.ComponentModel.DataAnnotations;

namespace EstudoRepositories.Models.DTOs
{
    public record MultadosDTO(long Id, long VeiculoId, string NomeCompleto, string CPF, string Placa, string Marca);
}
