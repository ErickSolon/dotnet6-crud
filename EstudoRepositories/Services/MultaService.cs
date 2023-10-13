using EstudoRepositories.Models;
using EstudoRepositories.Models.DTOs;
using EstudoRepositories.Repositories.Interfaces;

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
                MultadosDTO.Add(new MultadosDTO(item.Id, item.Veiculo.Id, item.NomeCompleto, item.CPF, item.Veiculo.Placa, item.Veiculo.Marca));
            }

            return MultadosDTO;
        }

        public async Task<MultadosDTO> ReadCondutorById(long id)
        {
            var Condutor = await _repository.GetCondutor(id);

            if (Condutor != null)
            {
                var Multado = new MultadosDTO(Condutor.Id, Condutor.Veiculo.Id, Condutor.NomeCompleto, Condutor.CPF, Condutor.Veiculo.Placa, Condutor.Veiculo.Marca);
                return Multado;
            }
            return null;
        }

        public async Task UpdateCondutor(long id, Condutor condutor)
        {
            await _repository.UpdateCondutor(id, condutor);
        }
    }
}
