using Microsoft.AspNetCore.Mvc;
using StoneChallenge.Application.Interfaces;
using StoneChallenge.Domain.Interfaces.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace StoneChallenge.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    public class DistribuicaoLucrosController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IPesosDistribuicaoLucrosService _pesosDistribuicaoLucrosService;
        private readonly ILogger<DistribuicaoLucrosController> _logger;

        public DistribuicaoLucrosController(ILogger<DistribuicaoLucrosController> logger,
                                            IFuncionarioRepository funcionarioRepository,
                                            IPesosDistribuicaoLucrosService pesosDistribuicaoLucrosService)
        {
            _logger = logger;
            _funcionarioRepository = funcionarioRepository;
            _pesosDistribuicaoLucrosService = pesosDistribuicaoLucrosService;
        }

        [HttpGet("calcular-bonus")]
        [SwaggerOperation(
            Summary = "Calcula o bônus de cada funcionário",
            Description = "Reparte os lucros entre os funcionários baseado em pesos de acordo com a área, tempo de empresa e faixa salarial."
            )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<double>>> calcularBonus()
        {
            var funcionarios = await _funcionarioRepository.GetAll();

            for (int cont = 0; cont <= funcionarios.Count(); cont ++) {
                var pesoSalario = _pesosDistribuicaoLucrosService.CalculaPesoSalario(funcionarios[cont]);
                var pesoDataAdmissao = _pesosDistribuicaoLucrosService.CalculaPesoDataAdmissao(funcionarios[cont]);
                var pesoAreaAtuacao = _pesosDistribuicaoLucrosService.CalculaPesoAreaAtuacao(funcionarios[cont]);

                var bonusIndividual = ((funcionarios[cont].Salario * pesoDataAdmissao) +
                                      (funcionarios[cont].Salario * pesoDataAdmissao) /
                                      funcionarios[cont].Salario * pesoSalario) * 12;
            }

            return Ok(funcionarios);
        }
    }
}
