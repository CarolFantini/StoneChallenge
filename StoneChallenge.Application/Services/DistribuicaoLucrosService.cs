using StoneChallenge.Application.Interfaces.Services;
using StoneChallenge.Application.ViewModels;
using StoneChallenge.Domain.Entities;
using StoneChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Application.Services
{
    public class DistribuicaoLucrosService : IDistribuicaoLucrosService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IPesosDistribuicaoLucrosService _pesosDistribuicaoLucrosService;

        public DistribuicaoLucrosService(IFuncionarioRepository funcionarioRepository,
                                         IPesosDistribuicaoLucrosService pesosDistribuicaoLucrosService)
        {
            _funcionarioRepository = funcionarioRepository;
            _pesosDistribuicaoLucrosService = pesosDistribuicaoLucrosService;
        }

        public async Task<DistribuicaoLucroViewModel> calculaBonus(double total_disponibilizado)
        {
            DistribuicaoLucroViewModel distribuicaoLucro = new DistribuicaoLucroViewModel();
            var total_distribuido = 0.0;
            var bonusIndividual = 0.0;

            var funcionarios = await _funcionarioRepository.GetAll();

            if (!funcionarios.Any())
            {
                distribuicaoLucro.total_de_funcionarios = 0;

                return distribuicaoLucro;
            }

            for (int cont = 1; cont < funcionarios.Count(); cont++)
            {
                var pesoAreaAtuacao = _pesosDistribuicaoLucrosService.CalculaPesoAreaAtuacao(funcionarios[cont]);
                var pesoSalario = _pesosDistribuicaoLucrosService.CalculaPesoSalario(funcionarios[cont]);
                var pesoDataAdmissao = _pesosDistribuicaoLucrosService.CalculaPesoDataAdmissao(funcionarios[cont]);

                if (pesoAreaAtuacao.Result == 0 || pesoSalario == 0 || pesoDataAdmissao == 0)
                {
                    return distribuicaoLucro;
                }

                bonusIndividual = (funcionarios[cont].Salario * pesoDataAdmissao) + (funcionarios[cont].Salario * pesoAreaAtuacao.Result) / (funcionarios[cont].Salario * pesoSalario) * 12;

                total_distribuido += bonusIndividual;

                distribuicaoLucro.participacoes.Add(new
                {
                    matricula = funcionarios[cont].Matricula,
                    nome = funcionarios[cont].Nome,
                    valor_da_participação = bonusIndividual.ToString("C", CultureInfo.CurrentCulture)
                });
            }

            distribuicaoLucro.total_de_funcionarios = funcionarios.Count();
            distribuicaoLucro.total_distribuido = total_distribuido;
            distribuicaoLucro.total_disponibilizado = total_disponibilizado;
            distribuicaoLucro.saldo_total_disponibilizado = total_disponibilizado - distribuicaoLucro.total_distribuido;

            return distribuicaoLucro;
        }
    }
}
