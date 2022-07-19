using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StoneChallenge.API.Controllers;
using StoneChallenge.Application.Interfaces;
using StoneChallenge.Domain.Entities;
using StoneChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Tests.Controllers
{
    public class DistribuicaoLucrosControllerTests
    {
        private readonly Mock<ILogger<DistribuicaoLucrosController>> _logger;
        private readonly Mock<IFuncionarioRepository> _funcionarioRepository;
        private readonly Mock<IPesosDistribuicaoLucrosService> _pesosDistribuicaoLucrosService;
        private readonly DistribuicaoLucrosController _distribuicaoLucrosController;

        public DistribuicaoLucrosControllerTests()
        {
            _logger = new Mock<ILogger<DistribuicaoLucrosController>>();
            _funcionarioRepository = new Mock<IFuncionarioRepository>();
            _pesosDistribuicaoLucrosService = new Mock<IPesosDistribuicaoLucrosService>();
            _distribuicaoLucrosController = new DistribuicaoLucrosController(_logger.Object, _funcionarioRepository.Object, _pesosDistribuicaoLucrosService.Object);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public async Task InformaDistribuicaoLucroShouldReturnOkTest(int peso)
        {
            IList<Funcionario> funcionarios = new List<Funcionario>
            {
                new Funcionario
                {
                     AreaAtuacao = "Tecnologia",
                     Cargo = "Analista de Sistemas",
                     DataAdmissao = DateTime.Now.Date,
                     Matricula = "U2154",
                     Nome = "Camila Ferraz",
                     Salario = 15000
                }
            };
            Funcionario funcionario = new Funcionario();
            double total_disponibilizado = 50000000;

            _funcionarioRepository.Setup(x => x.GetAll()).ReturnsAsync(funcionarios).Verifiable();
            _pesosDistribuicaoLucrosService.Setup(x => x.CalculaPesoSalario(funcionario)).Returns(peso).Verifiable();
            _pesosDistribuicaoLucrosService.Setup(x => x.CalculaPesoAreaAtuacao(funcionario)).Returns(() => Task.FromResult(peso)).Verifiable();
            _pesosDistribuicaoLucrosService.Setup(x => x.CalculaPesoDataAdmissao(funcionario)).Returns(peso).Verifiable();

            var result = await _distribuicaoLucrosController.InformaDistribuicaoLucro(total_disponibilizado);

            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public async Task InformaDistribuicaoLucroShouldReturnNotFoundTest(int peso)
        {
            IList<Funcionario> funcionarios = new List<Funcionario>();
            Funcionario funcionario = new Funcionario
            {
                AreaAtuacao = "Contabilidade",
                Cargo = "Contadora",
                DataAdmissao = DateTime.Now.Date,
                Matricula = "U5487",
                Nome = "Fernanda Ferraz",
                Salario = 5000
            };
            double total_disponibilizado = 50000000;

            _funcionarioRepository.Setup(x => x.GetAll()).ReturnsAsync(funcionarios).Verifiable();
            _pesosDistribuicaoLucrosService.Setup(x => x.CalculaPesoSalario(funcionario)).Returns(peso).Verifiable();
            _pesosDistribuicaoLucrosService.Setup(x => x.CalculaPesoAreaAtuacao(funcionario)).Returns(() => Task.FromResult(peso)).Verifiable();
            _pesosDistribuicaoLucrosService.Setup(x => x.CalculaPesoDataAdmissao(funcionario)).Returns(peso).Verifiable();

            var result = await _distribuicaoLucrosController.InformaDistribuicaoLucro(total_disponibilizado);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
