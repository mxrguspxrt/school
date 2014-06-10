using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TankServer.Models;

namespace TankServer.Controllers
{
    public class GamesController : ApiController
    {
        // GET api/games
        public List<Game> Get()
        {
            return Game.All();
        }

        // GET api/games/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/games
        public void Post([FromBody]string value)
        {
        }

        // PUT api/games/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/games/5
        public void Delete(int id)
        {
        }
    }
}
