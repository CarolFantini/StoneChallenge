using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StoneChallenge.API.Controllers;
using StoneChallenge.Application.Interfaces.Services;
using StoneChallenge.Application.ViewModels;
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
        private readonly Mock<IDistribuicaoLucrosService> _distribuicaoLucrosService;
        private readonly DistribuicaoLucrosController _distribuicaoLucrosController;

        public DistribuicaoLucrosControllerTests()
        {
            _logger = new Mock<ILogger<DistribuicaoLucrosController>>();
            _distribuicaoLucrosService = new Mock<IDistribuicaoLucrosService>();
            _distribuicaoLucrosController = new DistribuicaoLucrosController(_logger.Object,
                                                                             _distribuicaoLucrosService.Object);
        }

        [Fact]
        public async Task InformaDistribuicaoLucroShouldReturnOkTest()
        {
            var total_disponibilizado = 50000000;
            DistribuicaoLucroViewModel distribuicaoLucro = new DistribuicaoLucroViewModel
            {
                total_de_funcionarios = 5,
                total_disponibilizado = "50000",
                total_distribuido = "5000",
                saldo_total_disponibilizado = (Convert.ToInt64(total_disponibilizado) - 5000).ToString(),
                participacoes = { }
            };


            _distribuicaoLucrosService.Setup(x => x.calculaBonus(total_disponibilizado)).ReturnsAsync(distribuicaoLucro).Verifiable();

            var result = await _distribuicaoLucrosController.InformaDistribuicaoLucro(total_disponibilizado);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task InformaDistribuicaoLucroShouldReturnNotFoundTest()
        {
            DistribuicaoLucroViewModel distribuicaoLucro = new DistribuicaoLucroViewModel();
            distribuicaoLucro.total_de_funcionarios = 0;
            double total_disponibilizado = 50000000;

            _distribuicaoLucrosService.Setup(x => x.calculaBonus(total_disponibilizado)).ReturnsAsync(distribuicaoLucro).Verifiable();

            var result = await _distribuicaoLucrosController.InformaDistribuicaoLucro(total_disponibilizado);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
