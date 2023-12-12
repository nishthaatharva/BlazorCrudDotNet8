using BlazorCrudDotNet8.Application.Abstract;
using BlazorCrudDotNet8.Domain.Entities;
using System.Net.Http.Json;

namespace BlazorCrudDotNet8.Infrastructure.Services
{
    public class ClientGameService : IGameService
    {
        private readonly HttpClient _httpClient;

        public ClientGameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Game> AddGame(Game game)
        {
            var result = await _httpClient
                 .PostAsJsonAsync("/api/game", game);
            return await result.Content.ReadFromJsonAsync<Game>();
        }

        public async Task<bool> DeleteGame(int id)
        {
            var result = await _httpClient.DeleteAsync($"/api/game/{id}");
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<Game> EditGame(int id, Game game)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/game/{id}", game);
            return await result.Content.ReadFromJsonAsync<Game>();
        }

        public async Task<List<Game>> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetGameById(int id)
        {
            var results = await _httpClient
                 .GetFromJsonAsync<Game>($"/api/game/{id}");
            return results;
        }
    }
}