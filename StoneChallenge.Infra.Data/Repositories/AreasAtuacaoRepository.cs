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
        private DbConnection _dbConnection;

        public AreasAtuacaoRepository()
        {
            _dbConnection = new DbConnection();
        }

        public async Task<IDictionary<string, object>> GetAll()
        {
            var _firestoreDb = _dbConnection.CreateConnection();

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
