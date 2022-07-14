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
        private string DIRETORIO_CREDENCIAIS = "C:\\Users\\55219\\Downloads\\Repos\\StoneChallenge\\StoneChallenge.API\\stonechallenge-credentials.json";
        private string ID_PROJETO = "stonechallenge-21808";
        private FirestoreDb _firestoreDb;

        public FuncionarioRepository()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", DIRETORIO_CREDENCIAIS);
            _firestoreDb = FirestoreDb.Create(ID_PROJETO);
        }

        public async Task<IDictionary<string, object>> GetAll()
        {
            CollectionReference usersRef = _firestoreDb.Collection("funcionarios");
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            IDictionary<string, object> documentDictionary = new Dictionary<string, object>();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    documentDictionary = document.ToDictionary();
                }
            }

            return documentDictionary;
        }
    }
}
