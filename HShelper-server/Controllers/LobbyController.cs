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
        public ActionResult<Lobby> CreateLobby([FromBody] ConfigData config)
        {
            var result = _lobbyService.createLobby(config);
            var resultCode = true;
            if (result == null)
                 return StatusCode(408);
            else
            {
                return result;
            }
        }
    }
}