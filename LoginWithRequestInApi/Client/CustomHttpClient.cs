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
            var clientData = await _client.PostAsJsonAsync("Login/Singin", data);
            var responseString = await clientData.Content.ReadFromJsonAsync<UserData>();         

        
            return responseString;
        }
    }
}
