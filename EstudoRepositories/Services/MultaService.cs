using EstudoRepositories.Data;
using EstudoRepositories.Models;
using EstudoRepositories.Models.DTOs;
using EstudoRepositories.Repositories;
using EstudoRepositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace EstudoRepositories.Services
{
    public class MultaService : IMultaService
    {
        private readonly ICondutorRepository _repository;

        public MultaService(ICondutorRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateCondutor(Condutor condutor)
        {
            await _repository.SaveCondutor(condutor);
        }

        public async Task DeleteCondutor(long id)
        {
            await _repository.DeleteCondutor(id);
        }

        public async Task<List<MultadosDTO>> ReadCondutores()
        {

            var Condutores = await _repository.GetCondutores();

            List<MultadosDTO> MultadosDTO = new();
            foreach (var item in Condutores)
            {
                MultadosDTO.Add(new MultadosDTO
                {
                    Id =  item.Id,
                    VeiculoId = item.Veiculo.Id,
                    NomeCompleto = item.NomeCompleto,
                    CPF = item.CPF,
                    Placa = item.Veiculo.Placa,
                    Marca = item.Veiculo.Marca
                });
            }

            return MultadosDTO;
        }

        public async Task<MultadosDTO> ReadCondutorById(long id)
        {
            var Condutor = await _repository.GetCondutor(id);

            if (Condutor != null)
            {
                var Multado = new MultadosDTO
                {
                    Id = Condutor.Id,
                    NomeCompleto = Condutor.NomeCompleto,
                    CPF = Condutor.CPF,
                    VeiculoId = Condutor.Veiculo.Id,
                    Placa = Condutor.Veiculo.Placa,
                    Marca = Condutor.Veiculo.Marca
                };

                return Multado;
            }
            return null;
        }

        public async Task UpdateCondutor(long id, Condutor condutor)
        {
            await _repository.UpdateCondutor(id, condutor);        }
    }
}
