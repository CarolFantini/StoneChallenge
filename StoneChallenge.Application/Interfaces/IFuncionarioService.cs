using StoneChallenge.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Application.Interfaces
{
    public  interface IFuncionarioService
    {
        Task<IDictionary<string, object>> GetAll();
    }
}
