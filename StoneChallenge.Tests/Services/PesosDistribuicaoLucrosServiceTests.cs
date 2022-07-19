using Moq;
using StoneChallenge.Application.Services;
using StoneChallenge.Domain.Entities;
using StoneChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Tests.Services
{
    public class PesosDistribuicaoLucrosServiceTests
    {
        private readonly Mock<IAreasAtuacaoRepository> _areasAtuacaoRepository;
        private readonly PesosDistribuicaoLucrosService _pesosDistribuicaoLucrosService;

        public PesosDistribuicaoLucrosServiceTests()
        {
            _areasAtuacaoRepository = new Mock<IAreasAtuacaoRepository>();
            _pesosDistribuicaoLucrosService = new PesosDistribuicaoLucrosService(_areasAtuacaoRepository.Object);
        }

        [Theory]
        [InlineData("2021-11-08", 1)]
        [InlineData("2012-03-04", 5)]
        [InlineData("2020-08-15", 2)]
        [InlineData("2018-07-23", 3)]
        public async Task CalculaPesoDataAdmissaoShouldReturnValidTest(DateTime dataAdmissao, int pesoDataAdmissao)
        {
            Funcionario funcionario = new Funcionario
            {
                AreaAtuacao = "Tecnologia",
                Cargo = "Analista de Sistemas",
                DataAdmissao = dataAdmissao,
                Matricula = "U2154",
                Nome = "Camila Ferraz",
                Salario = 15000
            };

            var result = _pesosDistribuicaoLucrosService.CalculaPesoDataAdmissao(funcionario);

            Assert.True(result.Equals(pesoDataAdmissao));
        }

        [Theory]
        [InlineData(10908, 5)]
        [InlineData(7272, 3)]
        [InlineData(4848, 2)]
        [InlineData(2424, 1)]
        public async Task CalculaPesoSalarioShouldReturnValidTest(double salario, int pesoSalario)
        {
            Funcionario funcionario = new Funcionario
            {
                AreaAtuacao = "Tecnologia",
                Cargo = "Analista de Sistemas",
                DataAdmissao = DateTime.Now.Date,
                Matricula = "U2154",
                Nome = "Camila Ferraz",
                Salario = salario
            };

            var result = _pesosDistribuicaoLucrosService.CalculaPesoSalario(funcionario);

            Assert.True(result.Equals(pesoSalario));
        }

        [Theory]
        [InlineData("Tecnologia", 2)]
        [InlineData("Diretoria", 1)]
        [InlineData("Relacionamento com o Cliente", 5)]
        [InlineData("Serviços Gerais", 3)]
        public async Task CalculaPesoAreaAtuacaoShouldReturnValidTest(string areaAtuacao, int pesoAreaAtuacao)
        {
            IDictionary<string, object> areasDeAtuacao = new Dictionary<string, object>()
            {
                {"Tecnologia", 2},
                {"Diretoria", 1},
                {"Serviços Gerais", 3},
                {"Relacionamento com o Cliente", 5},
                {"Contabilidade", 2},
                {"Financeiro", 2}
            };
            Funcionario funcionario = new Funcionario
            {
                AreaAtuacao = areaAtuacao,
                Cargo = "Analista de Sistemas",
                DataAdmissao = DateTime.Now.Date,
                Matricula = "U2154",
                Nome = "Camila Ferraz",
                Salario = 1212
            };

            _areasAtuacaoRepository.Setup(x => x.GetAll()).Returns(() => Task.FromResult(areasDeAtuacao)).Verifiable();

            var result = _pesosDistribuicaoLucrosService.CalculaPesoAreaAtuacao(funcionario);

            Assert.True(result.Result.Equals(pesoAreaAtuacao));
        }
    }
}
