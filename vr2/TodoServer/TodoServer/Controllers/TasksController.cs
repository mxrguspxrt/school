using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TodoServer.Models;

namespace TodoServer.Controllers
{
    public class TasksController : ApiController
    {

        // GET api/games
        public List<Task> Get()
        {
            return Task.All().ToList();
        }

        // GET api/games/5
        public Task Get(int id)
        {
            Task task = Task.Find(id);
            return task;
        }

        // POST api/games
        public Task Post(Task task)
        {
            task.Save();
            return task;
        }

        // PUT api/games/5
        public Task Put(int id, Task values)
        {
            Task first = Task.Find(id);
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
