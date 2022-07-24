using Microsoft.AspNetCore.Mvc;
using StoneChallenge.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace StoneChallenge.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    public class DistribuicaoLucrosController : Controller
    {
        private readonly ILogger<DistribuicaoLucrosController> _logger;
        private readonly IDistribuicaoLucrosService _distribuicaoLucrosService;

        public DistribuicaoLucrosController(ILogger<DistribuicaoLucrosController> logger,
                                            IDistribuicaoLucrosService distribuicaoLucrosService)
        {
            _logger = logger;
            _distribuicaoLucrosService = distribuicaoLucrosService;
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
            var distribuicaoLucros = await _distribuicaoLucrosService.calculaBonus(total_disponibilizado);

            if (distribuicaoLucros.total_de_funcionarios == 0)
            {
                _logger.LogWarning("Funcionários não encontrados.");

                return NotFound();
            }

            return Ok(distribuicaoLucros);
        }
    }
}
