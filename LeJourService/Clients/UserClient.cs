using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using LeJourModel;

namespace LeJourService.Clients
{
    class UserClient
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var repositories = await ProcessRepositories();

            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.idUser);
                Console.WriteLine(repo.dtCreated);
                Console.WriteLine();
            }
        }

        private static async Task<List<User>> ProcessRepositories()
        {
            var streamTask = client.GetStreamAsync("https://sheet2api.com/v1/ByR2h1huRjyQ/fiap/users");
            var repositories = await JsonSerializer.DeserializeAsync<List<User>>(await streamTask);
            return repositories;
        }
    }
}
