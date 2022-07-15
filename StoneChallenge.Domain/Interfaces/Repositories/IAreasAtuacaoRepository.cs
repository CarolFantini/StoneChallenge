using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Domain.Interfaces.Repositories
{
    public interface IAreasAtuacaoRepository
    {
        Task<IDictionary<string, object>> GetAll();
        Task<bool> InsertAreasDeAtuacao(IDictionary<string, object> areasAtuacao);
    }
}
