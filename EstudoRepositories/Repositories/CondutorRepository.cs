using EstudoRepositories.Data;
using EstudoRepositories.Models;
using EstudoRepositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstudoRepositories.Repositories
{
    public class CondutorRepository : ICondutorRepository
    {
        private readonly ProjetoContext _context;

        public CondutorRepository(ProjetoContext context)
        {
            _context = context;    
        }

        public async Task<bool> DeleteCondutor(long id)
        {
            var Condutor = await GetCondutor(id);

            if(Condutor == null)
            {
                return false;
            }

            _context.Remove(Condutor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Condutor> GetCondutor(long id)
        {
            return await _context.Condutor.Include(c => c.Veiculo).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Condutor>> GetCondutores()
        {
            return await _context.Condutor.Include(c => c.Veiculo).ToListAsync();
        }

        public async Task<Condutor> SaveCondutor(Condutor condutor)
        {
            await _context.Condutor.AddAsync(condutor);
            await _context.SaveChangesAsync();

            return condutor;
        }

        public async Task<Condutor> UpdateCondutor(long id, Condutor condutor)
        {
            Condutor Condutor = await GetCondutor(id);

            Condutor.CPF = condutor.CPF;
            Condutor.NomeCompleto = condutor.NomeCompleto;
            Condutor.Veiculo.Marca = condutor.Veiculo.Marca;
            Condutor.Veiculo.Placa = condutor.Veiculo.Placa;

            await _context.SaveChangesAsync();

            return Condutor;
        }
    }
}
