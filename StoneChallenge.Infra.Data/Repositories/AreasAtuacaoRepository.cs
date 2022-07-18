using Google.Cloud.Firestore;
using StoneChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Infra.Data.Repositories
{
    public class AreasAtuacaoRepository : IAreasAtuacaoRepository
    {
        private string CREDENCIAIS;
        private const string ID_PROJETO = "stonechallenge-21808";
        private FirestoreDb _firestoreDb;

        public AreasAtuacaoRepository()
        {
            CREDENCIAIS = AppContext.BaseDirectory + @"stonechallenge-credentials.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", CREDENCIAIS);
            _firestoreDb = FirestoreDb.Create(ID_PROJETO);
        }

        public async Task<IDictionary<string, object>> GetAll()
        {
            CollectionReference collectionAreas = _firestoreDb.Collection("areas-atuacao");
            QuerySnapshot snapshotAreas = await collectionAreas.GetSnapshotAsync();
            IDictionary<string, object> areasDeAtuacao = new Dictionary<string, object>();

            foreach (DocumentSnapshot document in snapshotAreas.Documents)
            {
                var KeyValuePair = document.ToDictionary();
                areasDeAtuacao.Add(KeyValuePair.First());
            }

            return areasDeAtuacao;
        }
    }
}
