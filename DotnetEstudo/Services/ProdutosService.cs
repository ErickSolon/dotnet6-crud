using DotnetEstudo.Data;
using DotnetEstudo.Models;
using DotnetEstudo.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DotnetEstudo.Services
{
    public class ProdutosService : ControllerBase, IProdutosService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProdutosService> _logger;

        public ProdutosService(AppDbContext context, ILogger<ProdutosService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult DeletebyId(int id)
        {
            try
            {
                var Produto = _context.Produtos.SingleOrDefault(x => x.Id == id);

                if (Produto == null)
                {
                    return NotFound("Produto não existe, nada foi excluído!");
                }

                _logger.LogInformation($"Dado deletado! {id}");
                _context.Produtos.Remove(Produto);
                _context.SaveChanges();
            } catch(Exception e)
            {
                _logger.LogError($"Erro na classe: {nameof(DeletebyId)}, StackTrace: {e.StackTrace}");
            }

            return NoContent();
        }

        public IActionResult GetAll(int page, int size)
        {
            try
            {
                if (page < 1 || size < 1)
                {
                    return BadRequest("Valores inválidos para 'page' ou 'size'.");
                }

                var skipCount = (page - 1) * size;

                var Resultado = _context.Produtos
                    .Skip(skipCount)
                    .Take(size)
                    .ToList();

                if (Resultado == null || Resultado.Count == 0)
                {
                    return Problem("Não foi encontrado nenhum dado!");
                }

                List<ProdutosDTO> produtosDTOs = new();

                foreach (var item in Resultado)
                {
                    produtosDTOs.Add(new ProdutosDTO
                    {
                        Id = item.Id,
                        Titulo = item.Titulo
                    });
                }

                _logger.LogInformation($"Total de dados em uma requisição: {produtosDTOs.Count.ToString()}");
                return Ok(produtosDTOs);
            } catch(Exception e)
            {
                _logger.LogError($"Erro na classe: {nameof(GetAll)}, StackTrace: {e.StackTrace}");
            }

            return NoContent();
        }


        public IActionResult GetById(int id)
        {
            try
            {
                var Resultado = _context.Produtos.SingleOrDefault(x => x.Id == id);

                if (Resultado == null)
                {
                    return NotFound("Dados sobre o produto não foram encontrados!");
                }

                var produtosDTOs = new ProdutosDTO
                {
                    Id = Resultado.Id,
                    Titulo = Resultado.Titulo
                };

                _logger.LogInformation($"Id do dado requisitado: {id}");
                return Ok(produtosDTOs);
            } catch(Exception e)
            {
                _logger.LogError($"Erro na classe: {nameof(GetById)}, StackTrace: {e.StackTrace}");
            }

            return NoContent();
        }

        public IActionResult SaveProduto(Produtos produtos)
        {
            try
            {
                if (produtos == null)
                {
                    return Problem("Digite os campos para salvar os dados!");
                }

                _context.Produtos.Add(produtos);
                _context.SaveChanges();

                _logger.LogInformation($"Dado salvo: {produtos.Id}");
                return CreatedAtAction(nameof(GetById), new { id = produtos.Id }, produtos);
            } catch(Exception e)
            {
                _logger.LogError($"Erro na classe: {nameof(SaveProduto)}, StackTrace: {e.StackTrace}");
            }

            return NoContent();
            
        }

        public IActionResult UpdateById(int id, Produtos produtos)
        {
            try
            {
                var Produto = _context.Produtos.SingleOrDefault(x => x.Id == id);

                if (produtos.Id == 0)
                {
                    return Problem("Id não pode ser 0!");
                }

                if (Produto == null)
                {
                    return NotFound("Produto inexistente! nada foi atualizado!");
                }

                Produto.Titulo = produtos.Titulo;
                Produto.QtdVendida = produtos.QtdVendida;

                _context.SaveChanges();

                _logger.LogInformation($"Dado atualizado! {id}");
                return Ok(Produto);
            } catch(Exception e)
            {
                _logger.LogError($"Erro na classe: {nameof(UpdateById)}, StackTrace: {e.StackTrace}");
            }

            return NoContent();
        }
    }
}
