using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using backend.Models;
using backend.Controllers;

namespace backend.Controllers
{
    [Route("api/biblioteca")]
    [ApiController]
    public class BibliotecaAPI : ControllerBase
    {
        private readonly BibliotecaDbContext _context;
        public BibliotecaAPI(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resultados = _context.LivrosModel.Where(d => !d.IsDeleted).ToList();
            return Ok(resultados);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var resultados = _context.LivrosModel.Where(x => x.Id == id).ToList();

            if (resultados == null)
            {
                return NotFound();
            }

            return Ok(resultados);
        }

        [HttpPost]
        public IActionResult Save(Livros livros)
        {
            _context.LivrosModel.Add(livros);
            return CreatedAtAction(nameof(GetById), new { id = livros.Id }, livros);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Livros livros)
        {
            var resultados = _context.LivrosModel.SingleOrDefault(x => x.Id == id);

            if (resultados == null)
            {
                return NotFound();
            }

            resultados.Update(livros.Title, livros.Author, livros.Description);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var resultados = _context.LivrosModel.SingleOrDefault(x => x.Id == id);

            if (resultados == null)
            {
                return NotFound();
            }

            resultados.Delete();

            return NoContent();
        }
    }
}