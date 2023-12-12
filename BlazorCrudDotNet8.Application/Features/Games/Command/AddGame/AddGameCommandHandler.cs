using BlazorCrudDotNet8.Application.Abstract;
using BlazorCrudDotNet8.Domain.Entities;
using MediatR;

namespace BlazorCrudDotNet8.Application.Features.Games.Command
{
    public class AddGameCommand : IRequest<Game>
    {
        public Game Game { get; set; }
    }


    public class AddGameCommandHandler : IRequestHandler<AddGameCommand, Game>
    {
        private readonly IGameService _gameService;

        public AddGameCommandHandler(IGameService gameService)
        {
            _gameService = gameService;
        }


        public async Task<Game> Handle(AddGameCommand request, CancellationToken cancellationToken)
        {
            return await _gameService.AddGame(request.Game);
        }
    }
}
