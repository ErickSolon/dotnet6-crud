using EstudoRepositories.Data;
using EstudoRepositories.Models;
using EstudoRepositories.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace EstudoRepositories.Services
{
    public class MultaService : IMultaService
    {
        private readonly ProjetoContext _context;

        public MultaService(ProjetoContext context)
        {
            _context = context;
        }

        public async Task CreateCondutor(Condutor condutor)
        {
            await _context.Condutor.AddAsync(condutor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCondutor(long id)
        {
            var CondutorById = await _context.Condutor
                .Include(c => c.Veiculo)
                .SingleOrDefaultAsync(x => x.Id == id);
            _context.Condutor.Remove(CondutorById);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MultadosDTO>> ReadCondutores()
        {
            var Condutores = await _context.Condutor
                .Include(c => c.Veiculo)
                .ToListAsync();

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
            var Condutor = await _context.Condutor
                .Include(c => c.Veiculo)
                .SingleOrDefaultAsync(x => x.Id == id);

            if(Condutor != null)
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
            var CondutorById = await _context.Condutor
                .Include(c => c.Veiculo)
                .SingleOrDefaultAsync(x => x.Id == id);
            CondutorById.NomeCompleto = condutor.NomeCompleto;
            CondutorById.CPF = condutor.CPF;
            CondutorById.Veiculo.Marca = condutor.Veiculo.Marca;
            CondutorById.Veiculo.Placa = condutor.Veiculo.Placa;
            await _context.SaveChangesAsync();
        }
    }
}
