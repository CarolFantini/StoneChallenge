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

        public async Task<IDictionary<string, object>> GetAll()
        {
            CollectionReference collectionFuncionarios = _firestoreDb.Collection("funcionarios");
            QuerySnapshot snapshot = await collectionFuncionarios.GetSnapshotAsync();
            IDictionary<string, object> funcionarios = new Dictionary<string, object>();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    funcionarios = document.ToDictionary();
                }
            }

            return funcionarios;
        }
    }
}
