using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HShelper_server.Models;
using HShelper_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace HShelper_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LobbyController : Controller
    {
        private readonly LobbyService _lobbyService;
        public LobbyController(LobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }
        //POST /api/lobby
        [HttpPost]
        public async Task<ActionResult<Lobby>> CreateLobbyAsync([FromBody] ConfigData config)
        {
            var result = await _lobbyService.CreateLobbyAsync(config);
            if (result == null)
                return StatusCode(408);
            return result;
        }
        //GET /api/lobby
        [HttpGet]
        public async Task<ActionResult<List<Lobby>>> GetLobbyListAsync()
        {
            var result = await _lobbyService.GetAllLobbyAsync();
            if (result == null)
                return StatusCode(404);
            return result;
        }
        //GET /api/lobby/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Lobby>> GetLobbyAsync(string id)
        {
            var result = await _lobbyService.GetSingleLobbyAsync(id);
            if(result == null)
            {
                return StatusCode(404);
            }
            return result;
        }
    }
}