using StoneChallenge.Application.DTOs;
using StoneChallenge.Application.Interfaces;
using StoneChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<IDictionary<string, object>> GetAll()
        {
            var alunosEntity = await _funcionarioRepository.GetAll();
            // TO DO
            return alunosEntity;
        }
    }
}
