using System.Net.Http;

namespace StudentBackendApplicationData
{
    internal class Client
    {
        public string GetStudentsData()
        {
            using var client = new HttpClient();
            var response = client.GetAsync("https://localhost:7219/Backend").Result;

            return response.Content.ReadAsStringAsync().Result;

        }
    }
}
