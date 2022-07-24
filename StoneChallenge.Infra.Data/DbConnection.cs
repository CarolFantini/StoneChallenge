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
        public FirestoreDb CreateConnection(string credentialsJson, string idProjeto)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", AppContext.BaseDirectory + credentialsJson);
            return FirestoreDb.Create(idProjeto);
        }
    }
}