using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Application.ViewModels
{
    public class DistribuicaoLucroViewModel
    {
        public IList<object> participacoes { get; set; }
        public int total_de_funcionarios { get; set; }
        public double total_distribuido { get; set; }
        public double total_disponibilizado { get; set; }
        public double saldo_total_disponibilizado { get; set; }

        public DistribuicaoLucroViewModel()
        {
            participacoes = new List<object>();
        }
    }
}
