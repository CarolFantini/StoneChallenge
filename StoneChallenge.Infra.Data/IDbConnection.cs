using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChallenge.Infra.Data
{
    public interface IDbConnection
    {
        FirestoreDb CreateConnection(string credentialsJson, string idProjeto);
    }
}
