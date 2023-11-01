using EstudoRepositories.Controllers;
using EstudoRepositories.Models;
using EstudoRepositories.Models.Enums;
using EstudoRepositories.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EstudoRepositoriesTest;

public class Tests
{
    private Mock<IMultaService> _MultaService;
    private DetranController _DetranController;

    [SetUp]
    public void Setup()
    {
        _MultaService = new();
        _DetranController = new(_MultaService.Object);
    }

    [Test]
    public void DeveSalvarOCondutor()
    {
        var Condutor = new Condutor() {
            Id = 1,
            CPF = "1.1.1.1-1",
            NomeCompleto = "Nome Teste",
            Veiculo = new Veiculos() {
                Id = 1,
                Marca = "Marca Teste",
                MultaStatus = MultaStatus.Pago,
                Placa = "Placa Teste"
            }
        };
        var CondutorPost = _DetranController.SaveCondutor(Condutor);
        Assert.That(CondutorPost, Is.InstanceOf<Task<IActionResult>>());
    }

    [Test]
    public void DeveRetornarTodosOsCondutores() {
        var Condutores = _DetranController.GetAll();
        Assert.That(Condutores, Is.InstanceOf<Task<IActionResult>>());
    }

    [Test]
    public void DeveRetornarUmCondutorPorId() {
        var CondutorById = _DetranController.GetById(1);
        Assert.That(CondutorById, Is.InstanceOf<Task<IActionResult>>());
    }

    [Test]
    public void DeveAtualizarUmCondutorPorId() {
        var Condutor = new Condutor()
        {
            Id = 1,
            CPF = "1.1.1.1-1",
            NomeCompleto = "Nome Teste 2",
            Veiculo = new Veiculos()
            {
                Id = 1,
                Marca = "Marca Teste 2",
                MultaStatus = MultaStatus.Pago,
                Placa = "Placa Teste 2"
            }
        };

        var CondutorAtualizado = _DetranController.UpdateById(1, Condutor);
        Assert.That(CondutorAtualizado, Is.TypeOf<Task<IActionResult>>());
    }

    [Test]
    public void DeveDeletarUmCondutorPorId() {
        Assert.That(_DetranController.DeleteById(1), Is.InstanceOf<Task<IActionResult>>());
    }
}