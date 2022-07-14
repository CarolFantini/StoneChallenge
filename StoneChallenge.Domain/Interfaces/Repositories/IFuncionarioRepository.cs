using StoneChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<IDictionary<string, object>> GetAll();
    }
}
