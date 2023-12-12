using BlazorCrudDotNet8.Application.Abstract;
using BlazorCrudDotNet8.Domain.Entities;
using MediatR;

namespace BlazorCrudDotNet8.Application.Features.Games.Query
{
    public class GetGameByIdQuery : IRequest<Game>
    {
        public int Id { get; set; }
    }
    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, Game>
    {
        private readonly IGameService _gameService;

        public GetGameByIdQueryHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<Game> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            return await _gameService.GetGameById(request.Id);
        }
    }
}
