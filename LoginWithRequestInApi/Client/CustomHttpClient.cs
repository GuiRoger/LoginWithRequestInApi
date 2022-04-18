using LoginWithRequestInApi.Models;
using System.Text.Json;

namespace LoginWithRequestInApi.Client
{
    public class CustomHttpClient
    {
        private HttpClient _client;

        public CustomHttpClient(HttpClient client)
        {
            _client = client;
        }


        public async Task<UserData> Request(UserLogin data)
        {
            UserData result = null;
            //result.UserEmail = data.EmailUser;
            //result.UserPassword = data.Password;

            var clientData = await _client.PostAsJsonAsync("Login/Singin", data);
            var responseString = await clientData.Content.ReadAsStringAsync();

            clientData.EnsureSuccessStatusCode();
            


            return result;
        }
    }
}
