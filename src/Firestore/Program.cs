using System;
using Google.Cloud.Firestore;

namespace Firestore {
    class Program {
        static async System.Threading.Tasks.Task Main(string[] args) {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", $"{dir}/.google/issue-tagging-4711c12ef09a.json");

            var project = "github-issue-bot";
            var db = FirestoreDb.Create(project);

            var snapshot = await db.Collection("issues").GetSnapshotAsync();
            foreach (var item in snapshot.Documents) {
                Console.WriteLine(item.Id);
            }

            Console.ReadLine();
        }
    }
}
