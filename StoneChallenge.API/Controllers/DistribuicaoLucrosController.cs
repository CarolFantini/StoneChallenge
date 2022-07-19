using Microsoft.AspNetCore.Mvc;
using StoneChallenge.API.ViewModels;
using StoneChallenge.Application.Interfaces;
using StoneChallenge.Domain.Interfaces.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System.Globalization;

namespace StoneChallenge.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
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

        [HttpGet("informa-distribuicao-lucro")]
        [SwaggerOperation(
            Summary = "Retorna a distribuição de lucros entre os funcionários",
            Description = "Retorna os valores referentes a distribuição de lucros entre os funcionarios, " +
            "assim como total de funcionários, soma do que foi pago em PL a todos os funcionários, o valor que " +
            "a empresa desejava distribuir e o total disponibilizado menos o total distribuido."
            )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InformaDistribuicaoLucro(double total_disponibilizado)
        {
            DistribuicaoLucroViewModel distribuicaoLucro = new DistribuicaoLucroViewModel();
            var total_distribuido = 0.0;
            var bonusIndividual = 0.0;

            var funcionarios = await _funcionarioRepository.GetAll();

            if (!funcionarios.Any())
            {
                _logger.LogWarning("Funcionários não encontrados.");
                return NotFound();
            }

            distribuicaoLucro.total_de_funcionarios = funcionarios.Count();

            for (int cont = 1; cont < funcionarios.Count(); cont++)
            {
                var pesoAreaAtuacao = _pesosDistribuicaoLucrosService?.CalculaPesoAreaAtuacao(funcionarios[cont]);
                var pesoSalario = _pesosDistribuicaoLucrosService.CalculaPesoSalario(funcionarios[cont]);
                var pesoDataAdmissao = _pesosDistribuicaoLucrosService.CalculaPesoDataAdmissao(funcionarios[cont]);

                if (pesoAreaAtuacao.Result == 0 || pesoSalario == 0 || pesoDataAdmissao == 0)
                {
                    return new StatusCodeResult(500);
                }

                bonusIndividual = (funcionarios[cont].Salario * pesoDataAdmissao) + (funcionarios[cont].Salario * pesoAreaAtuacao.Result) / (funcionarios[cont].Salario * pesoSalario) * 12;

                total_distribuido += bonusIndividual;

                distribuicaoLucro.participacoes.Add(new
                {
                    matricula = funcionarios[cont].Matricula,
                    nome = funcionarios[cont].Nome,
                    valor_da_participação = bonusIndividual.ToString("C", CultureInfo.CurrentCulture)
                });

                distribuicaoLucro.total_distribuido = total_distribuido;
                distribuicaoLucro.total_disponibilizado = total_disponibilizado;
                distribuicaoLucro.saldo_total_disponibilizado = total_disponibilizado - distribuicaoLucro.total_distribuido;
            }
            return Ok(distribuicaoLucro);
        }
    }
}
