using Google.Cloud.Firestore;
using Newtonsoft.Json;
using StoneChallenge.Domain.Entities;
using StoneChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Infra.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private DbConnection _dbConnection;

        public FuncionarioRepository()
        {
            _dbConnection = new DbConnection();
        }

        public async Task<IList<Funcionario>> GetAll()
        {
            var _firestoreDb = _dbConnection.CreateConnection();

            CollectionReference collectionFuncionarios = _firestoreDb.Collection("funcionarios");
            QuerySnapshot snapshotFuncionarios = await collectionFuncionarios.GetSnapshotAsync();
            IList<Funcionario> funcionarios = new List<Funcionario>();

            foreach (DocumentSnapshot document in snapshotFuncionarios.Documents)
            {
                var funcionario = document.ToDictionary();

                funcionarios.Add(new Funcionario()
                {
                    Matricula = funcionario["matricula"].ToString(),
                    Nome = funcionario["nome"].ToString(),
                    AreaAtuacao = funcionario["area"].ToString(),
                    Cargo = funcionario["cargo"].ToString(),
                    Salario = (double)funcionario["salario_bruto"],
                    DataAdmissao = DateTime.Parse(funcionario["data_de_admissao"].ToString())
                });
            }

            return funcionarios;
        }
    }
}
