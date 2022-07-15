using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Domain.Entities
{
    public sealed class Funcionario
    {
        public string? Matricula { get; set; }
        public string? Nome { get; private set; }
        public string? AreaAtuacao { get; private set; }
        public string? Cargo { get; private set; }
        public float Salario { get; private set; }
        public DateTime DataAdmissao { get; private set; }
    }
}
