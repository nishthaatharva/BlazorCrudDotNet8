using BlazorCrudDotNet8.Domain.Entities;

namespace BlazorCrudDotNet8.Application.Abstract
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGames();
        Task<Game> GetGameById(int id);
        Task<Game> AddGame(Game game);
        Task<Game> EditGame(int id, Game game);
        Task<bool> DeleteGame(int id);
    }
}
