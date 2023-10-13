using EstudoRepositories.Models.Enums;

namespace EstudoRepositories.Models.DTOs;
public record MultadosDTO(
    long Id,
    long VeiculoId,
    string NomeCompleto,
    string CPF,
    string Placa,
    string Marca,
    MultaStatus MultaStatus
);
