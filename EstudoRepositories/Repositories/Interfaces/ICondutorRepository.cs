using EstudoRepositories.Models;

namespace EstudoRepositories.Repositories.Interfaces;
public interface ICondutorRepository
{
    Task<List<Condutor>> GetCondutores();
    Task<Condutor> GetCondutor(long id);
    Task<Condutor> SaveCondutor(Condutor condutor);
    Task<Condutor> UpdateCondutor(long id, Condutor condutor);
    Task<bool> DeleteCondutor(long id);
}
