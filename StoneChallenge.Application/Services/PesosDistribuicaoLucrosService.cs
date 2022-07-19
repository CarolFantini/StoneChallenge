using StoneChallenge.Application.Interfaces;
using StoneChallenge.Domain.Entities;
using StoneChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Application.Services
{
    public class PesosDistribuicaoLucrosService : IPesosDistribuicaoLucrosService
    {
        private readonly IAreasAtuacaoRepository _areasAtuacaoRepository;

        public PesosDistribuicaoLucrosService(IAreasAtuacaoRepository areasAtuacaoRepository)
        {
            _areasAtuacaoRepository = areasAtuacaoRepository;
        }

        public int CalculaPesoDataAdmissao(Funcionario funcionario)
        {
            const int DIAS_NO_ANO = 365;
            DateTime dataAtual = DateTime.Now.Date;
            int pesoDataAdmissao = 0;

            var DiferencaEntreDatas = (dataAtual - funcionario.DataAdmissao.Date).Days;

            DiferencaEntreDatas = DiferencaEntreDatas / DIAS_NO_ANO;

            switch (DiferencaEntreDatas)
            {
                case >= 8:
                    pesoDataAdmissao = 5;
                    break;
                case >= 3 and < 8:
                    pesoDataAdmissao = 3;
                    break;
                case > 1 and < 3:
                    pesoDataAdmissao = 2;
                    break;
                case <= 1:
                    pesoDataAdmissao = 1;
                    break;
            }

            return pesoDataAdmissao;
        }

        public async Task<int> CalculaPesoAreaAtuacao(Funcionario funcionario)
        {
            var areasDeAtuacao = await _areasAtuacaoRepository.GetAll();

            if (areasDeAtuacao.Any())
            {
                return Convert.ToInt32(areasDeAtuacao.Where(x => x.Key == funcionario.AreaAtuacao).FirstOrDefault().Value); ;
            }

            return 0;
        }

        public int CalculaPesoSalario(Funcionario funcionario)
        {
            const float SALARIO_MINIMO = 1212;
            int pesoSalario = 0;
            var multiplicadorSalarioMinimo = funcionario.Salario / SALARIO_MINIMO;

            switch (multiplicadorSalarioMinimo)
            {
                case >= 8:
                    pesoSalario = 5;
                    break;
                case >= 5 and < 8:
                    pesoSalario = 3;
                    break;
                case > 3 and < 5:
                    pesoSalario = 2;
                    break;
                case <= 3:
                    pesoSalario = 1;
                    break;
            }

            if (funcionario.Cargo == "Estagiário")
            {
                pesoSalario = 1;
            }

            return pesoSalario;
        }
    }
}
