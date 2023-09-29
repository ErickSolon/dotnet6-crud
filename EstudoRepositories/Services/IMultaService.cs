using EstudoRepositories.Models;
using EstudoRepositories.Models.DTOs;

namespace EstudoRepositories.Services
{
    public interface IMultaService
    {
        Task CreateCondutor(Condutor condutor);
        Task<List<MultadosDTO>> ReadCondutores();
        Task<MultadosDTO> ReadCondutorById(long id);
        Task UpdateCondutor(long id, Condutor condutor);
        Task DeleteCondutor(long id);
    }
}
