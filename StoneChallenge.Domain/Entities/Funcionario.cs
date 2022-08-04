using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Domain.Entities
{
    public sealed class Funcionario
    {
        public string? Matricula { get; set; }
        public string? Nome { get; set; }
        public string? AreaAtuacao { get; set; }
        public string? Cargo { get; set; }
        public double Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
    }
}
