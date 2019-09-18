using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Newtonsoft.Json;

namespace FirebaseDotNet {
    class Issue {
        [JsonProperty("title")]
        public string Title { set; get; }
        [JsonProperty("label")]
        public string Label { set; get; }
    }

    class Program {
        static async Task Main(string[] args) {

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyDXyczRuaZWskx43U-Pamzyw1YaUag79lY"));
            var sign = await authProvider.SignInAnonymouslyAsync();

            var firebase = new FirebaseClient("https://github-issue-bot.firebaseio.com", new FirebaseOptions {
                AuthTokenAsyncFactory = () => Task.FromResult(sign.FirebaseToken)
            });

            var child = firebase.Child("issues");

            var issue = new Issue { Title = "Title1", Label = "Label1" };
            var json = JsonConvert.SerializeObject(issue);
            await child.PostAsync(json);
        }
    }
}
