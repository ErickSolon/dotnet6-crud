using DotnetEstudo.Data;
using DotnetEstudo.Models;
using DotnetEstudo.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DotnetEstudo.Services
{
    public class ProdutosService : ControllerBase, IProdutosService
    {
        private readonly AppDbContext _context;

        public ProdutosService(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult DeletebyId(int Id)
        {
            var Produto = _context.Produtos.SingleOrDefault(x => x.Id == Id);

            if(Produto == null)
            {
                return NotFound("Produto não existe, nada foi excluído!");
            }

            _context.Produtos.Remove(Produto);
            _context.SaveChanges();

            return NoContent();
        }

        public IActionResult GetAll(int page, int size)
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

            return Ok(produtosDTOs);
        }


        public IActionResult GetById(int Id)
        {
            var Resultado = _context.Produtos.SingleOrDefault(x => x.Id == Id);

            if(Resultado == null)
            {
                return NotFound("Dados sobre o produto não foram encontrados!");
            }

            var produtosDTOs = new ProdutosDTO
            {
                Id = Resultado.Id,
                Titulo = Resultado.Titulo
            };

            return Ok(produtosDTOs);
        }

        public IActionResult SaveProduto(Produtos produtos)
        {
            if(produtos == null)
            {
                return Problem("Digite os campos para salvar os dados!");
            }

            _context.Produtos.Add(produtos);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = produtos.Id }, produtos);
        }

        public IActionResult UpdateById(int Id, Produtos produtos)
        {
            var Produto = _context.Produtos.SingleOrDefault(x => x.Id == Id);
            
            if(produtos.Id == 0)
            {
                return Problem("Id não pode ser 0!");
            }

            if(Produto == null)
            {
                return NotFound("Produto inexistente! nada foi atualizado!");
            }
            
            Produto.Titulo = produtos.Titulo;
            Produto.QtdVendida = produtos.QtdVendida;

            _context.SaveChanges();

            return Ok(Produto);
        }
    }
}
