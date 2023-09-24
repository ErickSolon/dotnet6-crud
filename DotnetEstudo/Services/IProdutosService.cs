using DotnetEstudo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetEstudo.Services
{
    public interface IProdutosService
    {
        IActionResult GetAll(int page, int size);
        IActionResult GetById(int Id);
        IActionResult UpdateById(int Id, Produtos produtos);
        IActionResult SaveProduto(Produtos produtos);
        IActionResult DeletebyId(int Id);
    }
}
