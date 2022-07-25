using Google.Cloud.Firestore;
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
        private IDbConnection _dbConnection;
        FirestoreDb _firestoreDb;

        public FuncionarioRepository()
        {
            _dbConnection = new DbConnection();
            _firestoreDb = _dbConnection.CreateConnection("stonechallenge-credentials.json", "stonechallenge-21808");
        }

        public async Task<IList<Funcionario>> GetAll()
        {
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
