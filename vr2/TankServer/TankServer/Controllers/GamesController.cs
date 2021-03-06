﻿using System;
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
            new Game() { Name = "Test" }.Save();
            Game first = Game.Find(1);
            first.Name = "changed";
            first.Save();
            return Game.All();
        }

        // GET api/games/5
        public Game Get(int id)
        {
            return Game.Find(id);
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
