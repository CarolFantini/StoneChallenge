using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Infra.Data
{
    public class DbConnection : IDbConnection
    {
        private string? CREDENCIAIS;
        private const string ID_PROJETO = "stonechallenge-21808";
        private FirestoreDb _firestoreDb;

        public FirestoreDb CreateConnection()
        {
            CREDENCIAIS = AppContext.BaseDirectory + @"stonechallenge-credentials.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", CREDENCIAIS);
            return FirestoreDb.Create(ID_PROJETO);
        }
    }

    public interface IDbConnection
    {
        FirestoreDb CreateConnection();
    }
}