using StoneChallenge.Application.ViewModels;
using StoneChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Application.Interfaces.Services
{
    public interface IDistribuicaoLucrosService
    {
        Task<DistribuicaoLucroViewModel> calculaBonus(double total_disponibilizado);
    }
}
