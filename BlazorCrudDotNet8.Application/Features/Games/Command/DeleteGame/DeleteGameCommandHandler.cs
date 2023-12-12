using BlazorCrudDotNet8.Application.Abstract;
using MediatR;

namespace BlazorCrudDotNet8.Application.Features.Games.Command
{
    public class DeleteGameCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, bool>
    {
        private readonly IGameService _gameService;

        public DeleteGameCommandHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            return await _gameService.DeleteGame(request.Id);
        }
    }
}
