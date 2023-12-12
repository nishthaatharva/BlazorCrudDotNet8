using BlazorCrudDotNet8.Application.Abstract;
using BlazorCrudDotNet8.Domain.Entities;
using MediatR;

namespace BlazorCrudDotNet8.Application.Features.Games.Command
{
    public class EditGameCommand : IRequest<Game>
    {
        public int Id { get; set; }
        public Game Game { get; set; }
    }
    public class EditGameCommandHandler : IRequestHandler<EditGameCommand, Game>
    {
        private readonly IGameService _gameService;

        public EditGameCommandHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<Game> Handle(EditGameCommand request, CancellationToken cancellationToken)
        {
            return await _gameService.EditGame(request.Id, request.Game);
        }
    }
}
