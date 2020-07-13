using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using GameManagerEntities.DTO;
using GameManagerEntities.Models;
using GamesManagerRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GamesManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IGameViewHistoriesRepository _historiesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GamesController(
            IGamesRepository gamesRepository,
            IMapper mapper,
            ILogger logger,
            IGameViewHistoriesRepository historiesRepository)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
            _logger = logger;
            _historiesRepository = historiesRepository;
        }

        /// <summary>
        /// Get all games from the database
        /// </summary>
        /// <returns>List of games</returns>
        [HttpGet]
        public async Task<ActionResult<List<GameDTO>>> GetAsync()
        {
            try
            {
                _logger.LogInformation("GetAsync has been called");

                var result = await _gamesRepository.GetAllGames().ToListAsync();
                return _mapper.Map<List<GameDTO>>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occured in GetAsync method");
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get single game
        /// </summary>
        /// <param name="id">ID of desired game</param>
        /// <returns>Single game</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDTO>> GetSingleAsync(int id)
        {
            if (id == 0)
            {
                _logger.LogError("ID in GetSingleAsync is 0");
                return BadRequest();
            }

            try
            {
                _logger.LogInformation("GetSingleAsync has been called", id);

                var result = await _gamesRepository.GetSingleGameAsync(id);
                
                // insert view history record for given game
                var historyEntry = await _historiesRepository.CreateHistoryEntryAsync(new GameViewHistory()
                {
                    Date = DateTime.Now,
                    GameId = id
                });

                if (result == null)
                {
                    _logger.LogInformation($"Game with ID of {id} was not found");
                    return NotFound();
                }

                return _mapper.Map<GameDTO>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occured in GetSingleAsync method");
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get history for single game
        /// </summary>
        /// <param name="id">ID of desired game</param>
        /// <returns>Collection of histories entries for game</returns>
        [HttpGet("{id}/history")]
        public async Task<ActionResult<List<GameViewHistoryDTO>>> GetHistoryAsync(int id)
        {
            if (id == 0)
            {
                _logger.LogError("ID in GetHistoryAsync is 0");
                return BadRequest();
            }
            
            try
            {
                _logger.LogInformation("GetHistoryAsync has been called", id);
                var result = await _historiesRepository.GetAllHistoriesForGame(id).ToListAsync();
                return _mapper.Map<List<GameViewHistoryDTO>>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occured in GetHistoryAsync method");
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Create new game
        /// </summary>
        /// <param name="game">New game object</param>
        /// <returns>Created game</returns>
        [HttpPost]
        public async Task<ActionResult<GameDTO>> CreateAsync(GameDTO game)
        {
            if (game == null)
            {
                _logger.LogError("CreateAsync was called with null parameter");
                return BadRequest();
            }

            try
            {
                _logger.LogInformation("CreateAsync has been called", game);
                var mappedGame = _mapper.Map<Game>(game);
                var result = await _gamesRepository.CreateGameAsync(mappedGame);

                if (result == null)
                {
                    _logger.LogError($"Game with ID of {game.Id} was not found");
                    return NotFound();
                }

                return Created($"api/games/{result.Id}", _mapper.Map<GameDTO>(result));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occured in CreateAsync method");
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Update existing game
        /// </summary>
        /// <param name="id">ID of desired game</param>
        /// <param name="game">Updated game object</param>
        [HttpPut("{id}")]
        public async Task<ActionResult<GameDTO>> UpdateAsync(int id, GameDTO game)
        {
            if (id == 0 || game == null)
            {
                _logger.LogError("UpdateAsync was called with a null argument");
                return BadRequest();
            }

            try
            {
                _logger.LogInformation("UpdateAsync has been called", game);
                var mappedGame = _mapper.Map<Game>(game);
                await _gamesRepository.UpdateGameAsync(id, mappedGame);

                return NoContent();
            }
            catch (RowNotInTableException e)
            {
                _logger.LogError(e, $"Game with ID of {id} was not found");
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception has occured in UpdateAsync method");
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Delete game
        /// </summary>
        /// <param name="id">ID of desired game</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameDTO>> DeleteAsync(int id)
        {
            if (id == 0)
            {
                _logger.LogError("DeleteAsync method has been called with ID of 0");
                return BadRequest();
            }

            try
            {
                _logger.LogInformation("DeleteAsync method has been called", id);
                var result = await _gamesRepository.DeleteGameAsync(id);
                return _mapper.Map<GameDTO>(result);
            }
            catch (RowNotInTableException e)
            {
                _logger.LogError(e, $"Game with ID of {id} was not found");
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception has occured in DeleteAsync method");
                return BadRequest(e.Message);
            }
        }
    }
}