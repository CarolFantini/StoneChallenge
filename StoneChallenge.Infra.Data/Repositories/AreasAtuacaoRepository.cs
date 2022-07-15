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
        private const string DIRETORIO_CREDENCIAIS = "C:\\Users\\55219\\Downloads\\Repos\\StoneChallenge\\StoneChallenge.API\\stonechallenge-credentials.json";
        private const string ID_PROJETO = "stonechallenge-21808";
        private FirestoreDb _firestoreDb;

        public AreasAtuacaoRepository()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", DIRETORIO_CREDENCIAIS);
            _firestoreDb = FirestoreDb.Create(ID_PROJETO);
        }

        public async Task<IDictionary<string, object>> GetAll()
        {
            CollectionReference collectionAreasDeAtuacao = _firestoreDb.Collection("funcionarios");
            QuerySnapshot snapshot = await collectionAreasDeAtuacao.GetSnapshotAsync();
            IDictionary<string, object> areasDeAtuacao = new Dictionary<string, object>();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    areasDeAtuacao = document.ToDictionary();
                }
            }

            return areasDeAtuacao;
        }

        public async Task<bool> InsertAreasDeAtuacao(IDictionary<string, object> areasAtuacao)
        {
            foreach (var area in areasAtuacao)
            {
                DocumentReference docRef = _firestoreDb.Collection("areas-de-atuacao").Document("areas");
                IDictionary<string, object> areaAtuacao = new Dictionary<string, object>
                {
                    { "nome", area.Key },
                    { "peso", area.Value },
                };

                await docRef.SetAsync(areaAtuacao);
            }
            return true;
        }
    }
}
