using System;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Firestore {
    class Program {

        static async Task Query(FirestoreDb db) {
            var snapshot = await db.Collection("issues").GetSnapshotAsync();
            foreach (var item in snapshot.Documents) {
                Console.WriteLine(item.GetValue<string>("title"));
            }
        }

        static async Task Main(string[] args) {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", $"{dir}/.google/github-issue-bot-322a4456bfdf.json");

            var project = "github-issue-bot";
            var db = FirestoreDb.Create(project);

            await Query(db);

            Console.ReadLine();
        }
    }
}
