using Microsoft.AspNetCore.Mvc;
using StoneChallenge.Application.Interfaces;

namespace StoneChallenge.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DistribuicaoLucrosController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly ILogger<DistribuicaoLucrosController> _logger;

        public DistribuicaoLucrosController(ILogger<DistribuicaoLucrosController> logger,
                            IFuncionarioService funcionarioService)
        {
            _logger = logger;
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IDictionary<string, object>>> GetAll()
        {
            var result = await _funcionarioService.GetAll();

            if (result == null)
            {
                _logger.LogError("GetAll Alunos falhou.");
                return NotFound("Alunos não encontrados.");
            }

            _logger.LogInformation("GetAll Alunos encontradas.");
            return Ok(result);
        }
    }
}
