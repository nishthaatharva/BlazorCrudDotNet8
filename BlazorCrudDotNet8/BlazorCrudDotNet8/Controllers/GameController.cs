using BlazorCrudDotNet8.Application.Abstract;
using BlazorCrudDotNet8.Application.Features.Games.Command;
using BlazorCrudDotNet8.Application.Features.Games.Query;
using BlazorCrudDotNet8.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGameService _gameService;

        public GameController(IGameService gameService, IMediator mediator)
        {
            _gameService = gameService;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameById(int id)
        {
            var query = new GetGameByIdQuery { Id = id };
            var game = await _mediator.Send(query);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGame([FromBody] Game game)
        {
            var command = new AddGameCommand { Game = game };
            var addedGame = await _mediator.Send(command);

            return Ok(addedGame);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> EditGame(int id, [FromBody] Game game)
        {
            var command = new EditGameCommand { Id = id, Game = game };
            var editedGame = await _mediator.Send(command);

            return Ok(editedGame);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteGame(int id)
        {
            var command = new DeleteGameCommand { Id = id };
            var isDeleted = await _mediator.Send(command);

            return Ok(isDeleted);
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetAllGames()
        {
            var query = new GetAllGamesQuery();
            var games = await _mediator.Send(query);

            return Ok(games);
        }
    }
}
