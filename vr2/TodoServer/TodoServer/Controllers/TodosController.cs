using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TodoServer.Models;

namespace TodoServer.Controllers
{
    public class TodosController : ApiController
    {

        // GET api/games
        public List<Todo> Get()
        {
            return Todo.All().ToList();
        }

        // GET api/games/5
        public Todo Get(int id)
        {
            return Todo.Find(id);
        }

        // POST api/games
        public Todo Post(Todo todo)
        {
            todo.Save();
            return todo;
        }

        // PUT api/games/5
        public Todo Put(int id, Todo values)
        {
            Todo first = Todo.Find(id);
            first.Headline = values.Headline;
            first.Description = values.Description;
            first.State = values.State;
            first.Save();
            return first;
        }

        // DELETE api/games/5
        public void Delete(int id)
        {
            Todo first = Todo.Find(id);
            first.Delete();
        }
    }
}
