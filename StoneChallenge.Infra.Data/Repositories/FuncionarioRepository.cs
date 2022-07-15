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
        private const string DIRETORIO_CREDENCIAIS = "C:\\Users\\55219\\Downloads\\Repos\\StoneChallenge\\StoneChallenge.API\\stonechallenge-credentials.json";
        private const string ID_PROJETO = "stonechallenge-21808";
        private FirestoreDb _firestoreDb;

        public FuncionarioRepository()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", DIRETORIO_CREDENCIAIS);
            _firestoreDb = FirestoreDb.Create(ID_PROJETO);
        }

        public async Task<IList<Funcionario>> GetAll()
        {
            CollectionReference collectionFuncionarios = _firestoreDb.Collection("funcionarios");
            QuerySnapshot snapshot = await collectionFuncionarios.GetSnapshotAsync();
            IList<Funcionario> funcionarios = new List<Funcionario>();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
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
            }

            return funcionarios;
        }
    }
}
