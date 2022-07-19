using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Domain.Entities
{
    [SwaggerSchema(Required = new[] { "Description" })]
    public sealed class Funcionario
    {
        [SwaggerSchema(Description = "Matrícula do funcionário")]
        [Required]
        public string? Matricula { get; set; }
        [SwaggerSchema(Description = "Nome do funcionário")]
        [Required]
        public string? Nome { get; set; }
        [SwaggerSchema(Description = "Área de atuação do funcionário")]
        [Required]
        public string? AreaAtuacao { get; set; }
        [SwaggerSchema(Description = "Cargo do funcionário")]
        [Required]
        public string? Cargo { get; set; }
        [SwaggerSchema(Description = "Salário do funcionário")]
        [Required]
        public double Salario { get; set; }
        [SwaggerSchema(Description = "Data de admissão do funcionário", Format = "date")]
        [Required]
        public DateTime DataAdmissao { get; set; }
    }
}
