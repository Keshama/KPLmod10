using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modul10_103022400060.Models;
using System.Linq;

namespace Modul10_103022400060.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameControllers : ControllerBase
    {
        private static List<Game> _gameList = new List<Game>()
        {
            new Game{ Nama = "Valorant", Developer = "Riot Games", TahunRilis =2020, Genre = "FPS", Rating = 8.5,
                Platform = ["PC"],Mode= ["Multiplayer"], IsOnline=true, Harga = 0  },
            new Game{ Nama = "GTA V", Developer = "Rockstar Games", TahunRilis =2013, Genre = "Open World", Rating = 9.5,
                Platform = ["PC","PS4", "PS5", "Xbox"],Mode= ["Singleplayer","Multiplayer"], IsOnline=true, Harga = 300000  },
            new Game{ Nama = "TheWitcher3", Developer = "CD Projekt Red", TahunRilis =2015, Genre = "RPG", Rating = 9.7,
                Platform = ["PC","PS4", "PS5", "Xbox"],Mode= ["Singleplayer"], IsOnline=false, Harga = 250000  },

        };

        [HttpGet]
        public ActionResult<Game> Get()
        {
            return Ok(_gameList);
        }

        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var game = _gameList.FirstOrDefault(f => f.Id == id );
            if (game == null)
            {
                return NotFound("Game tidak ditemukan");
            }
            return game;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Game gameBaru)
        {
            _gameList.Add(gameBaru);
            return Ok("Game berhasil ditambahkan");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var game = _gameList.FirstOrDefault(f => f.Id == id);
            if (game == null)
            {
                return NotFound("Game tidak ditemukan");
            }

            _gameList.Remove(game);
            return Ok("Game berhasil dihapus");

        }
    }
}
