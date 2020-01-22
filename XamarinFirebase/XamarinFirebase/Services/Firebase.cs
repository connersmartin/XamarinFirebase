using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebase.Models;
using Google.Cloud.Firestore;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore.V1;
using Grpc.Core;
using Grpc.Auth;

namespace XamarinFirebase.Services
{
    public class Firebase
    {
        public static readonly GoogleCredential gc = GoogleCredential.FromJson("");
        static readonly ChannelCredentials cc = gc.ToChannelCredentials();

        static Channel c = new Channel(FirestoreClient.DefaultEndpoint.ToString(), cc);
        static FirestoreClient fc = FirestoreClient.Create(c);
        //doesn't work need to figure out how to utlize the google credential here!
        FirestoreDb db = FirestoreDb.Create("xamarinfirebasea", client: fc);


        public async Task AddData(Dictionary<string,object> paramDict)
        {
            DocumentReference docRef = db.Collection("data").Document();

            await docRef.SetAsync(paramDict);
        }

        public async Task<List<Person>> GetData()
        {
            var p = new List<Person>();
            Query docRef = db.Collection("data");

            QuerySnapshot snapshot = await docRef.GetSnapshotAsync();

            foreach (DocumentSnapshot ds in snapshot.Documents)
            {
                var i = ds.GetValue<int>("ID");

                var j = ds.GetValue<string>("Name");

                p.Add(new Person()
                {
                    PersonId = i,
                    Name = j
                });
            
            }

            return p;
        }
    }
}
