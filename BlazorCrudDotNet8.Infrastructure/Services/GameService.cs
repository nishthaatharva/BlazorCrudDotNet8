using BlazorCrudDotNet8.Application.Abstract;
using BlazorCrudDotNet8.Domain.Entities;
using BlazorCrudDotNet8.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Infrastructure.Services
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;

        public GameService(DataContext context)
        {
            _context = context;
        }

        public async Task<Game> AddGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game;
        }

        public async Task<bool> DeleteGame(int id)
        {
            var bdGame = await _context.Games.FindAsync(id);
            if (bdGame != null)
            {
                _context.Games.Remove(bdGame);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Game> EditGame(int id, Game game)
        {
            var bdGame = await _context.Games.FindAsync(id);
            if (bdGame != null)
            {
                bdGame.Name = game.Name;
                await _context.SaveChangesAsync();
                return bdGame;
            }
            throw new Exception("No games found");
        }

        public async Task<List<Game>> GetAllGames()
        {
            var games = await _context.Games.ToListAsync();
            return games;
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _context.Games.FindAsync(id);
        }
    }
}
