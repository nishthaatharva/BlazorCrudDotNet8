using BlazorCrudDotNet8.Application.Abstract;
using BlazorCrudDotNet8.Domain.Entities;
using MediatR;

namespace BlazorCrudDotNet8.Application.Features.Games.Query
{
    public class GetAllGamesQuery : IRequest<List<Game>>
    {
    }
    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, List<Game>>
    {
        private readonly IGameService _gameService;

        public GetAllGamesQueryHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<List<Game>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            return await _gameService.GetAllGames();
        }
    }
}
