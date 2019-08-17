using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HShelper_server.Services;
using HShelper_server.Models;

namespace HShelper_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : Controller
    {
        public readonly CardService _cardService;
        public CardsController(CardService cardService)
        {
            _cardService = cardService;
        }

        //GET /api/cards
        [HttpGet]
        public async Task<ActionResult<List<Card>>> GetAsync() =>
            await _cardService.GetAsync();
    }
}