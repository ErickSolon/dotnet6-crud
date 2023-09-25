using DotnetEstudo.Models;
using DotnetEstudo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetEstudo.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosService _service;

        public ProdutosController(IProdutosService service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult Produtos(int page, int size)
        {
            return _service.GetAll(page, size);
        }

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public IActionResult SaveProduto(Produtos produtos)
        {
            return _service.SaveProduto(produtos);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProdutoById(int id, Produtos produtos)
        {
            return _service.UpdateById(id, produtos);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProdutoById(int id)
        {
            return _service.DeletebyId(id);
        }
    }
}
