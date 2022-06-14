using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kol2.DTOs;
using kol2.Entities.Models;
using kol2.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;


namespace kol2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IRepoS _service;
        public Controller(IRepoS service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusician(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Złe żądanie!");
            }

            return Ok(await _service.GetMusicianById(id).Select(e =>
                new MusicianDTO
                {
                    firstName = e.firstName,
                    lastName = e.lastName,
                    nickname = e.nickName,
                    Tracks = e.MusicianTrack.Select(e => new TrackDTO
                    {
                        idTrack = e.idTrack,
                        trackName = e.Track.trackName,
                        duration = e.Track.duration
                    }).ToList()
                }).ToListAsync());
        }
    }
    }
}
