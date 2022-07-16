﻿using Google.Cloud.Firestore;
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
