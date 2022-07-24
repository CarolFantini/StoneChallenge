using StoneChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Application.Interfaces.Services
{
    public interface IPesosDistribuicaoLucrosService
    {
        int CalculaPesoSalario(Funcionario funcionario);
        int CalculaPesoDataAdmissao(Funcionario funcionario);
        Task<int> CalculaPesoAreaAtuacao(Funcionario funcionario);
    }
}
