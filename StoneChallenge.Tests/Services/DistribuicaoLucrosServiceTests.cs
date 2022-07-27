using Moq;
using StoneChallenge.Application.Interfaces.Services;
using StoneChallenge.Application.Services;
using StoneChallenge.Application.ViewModels;
using StoneChallenge.Domain.Entities;
using StoneChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Tests.Services
{
    public class DistribuicaoLucrosServiceTests
    {
        private readonly Mock<IFuncionarioRepository> _funcionarioRepository;
        private readonly Mock<IPesosDistribuicaoLucrosService> _pesosDistribuicaoLucrosService;
        private readonly DistribuicaoLucrosService _distribuicaoLucrosService;

        public DistribuicaoLucrosServiceTests()
        {
            _funcionarioRepository = new Mock<IFuncionarioRepository>();
            _pesosDistribuicaoLucrosService = new Mock<IPesosDistribuicaoLucrosService>();
            _distribuicaoLucrosService = new DistribuicaoLucrosService(_funcionarioRepository.Object,
                                                                      _pesosDistribuicaoLucrosService.Object);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public async Task InformaDistribuicaoLucroShouldHaveAnyFuncionarioTest(int peso)
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

            var result = await _distribuicaoLucrosService.calculaBonus(total_disponibilizado);

            Assert.True(result.total_de_funcionarios >= 1);
        }
    }
}
