using EstudoRepositories.Models;
using EstudoRepositories.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstudoRepositories.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class DetranController : ControllerBase
    {
        private readonly IMultaService _service;

        public DetranController(IMultaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SaveCondutor(Condutor condutor)
        {
            try
            {
                await _service.CreateCondutor(condutor);
                return CreatedAtAction(
                    nameof(_service.ReadCondutorById),
                    new { id = condutor.Id }, condutor
                );
            }
            catch (Exception e)
            {
            {
                return Problem($"Problemas ao salvar o condutor! {e.Message.ToString()}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var condutores = await _service.ReadCondutores();

            if (condutores == null || !condutores.Any())
            {
                return NotFound("Nenhum condutor multado!");
            }

            return Ok(condutores);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var Resultado = await _service.ReadCondutorById(id);

            if (Resultado == null)
            {
                return NotFound("Condutor não encontrado ou não multado!");
            }

            return Ok(Resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(long id, Condutor condutor)
        {
            var Resultado = await _service.ReadCondutorById(id);

            if (Resultado == null)
            {
                return NotFound("Condutor não encontrado, por tanto nada atualizado!");
            }
            else
            {
                await _service.UpdateCondutor(id, condutor);
                return Ok("Dados do condutor atualizados com sucesso!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(long id)
        {
            var Resultado = await _service.ReadCondutorById(id);

            if (Resultado == null)
            {
                return NotFound("Condutor não encontrado, por tanto nada deletado!");
            }
            else
            {
                await _service.DeleteCondutor(id);
                return Ok($"{id} deletado com sucesso!");
            }
        }
    }
}
