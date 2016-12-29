using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace dotnet_core_api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // GET api/todos
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public Task<IEnumerable<Todo>> Get()
        {
            return GetTodoInternal();
        }

        private async Task<IEnumerable<Todo>> GetTodoInternal()
        {
            return await _todoRepository.GetAllTodos();
        }

        // GET api/todos/{id}
        [HttpGet("{id}")]
        public async Task<Todo> Get(string id)
        {
            return await _todoRepository.GetTodo(new ObjectId(id)) ?? new Todo();
        }

        // POST api/todos
        [HttpPost]
        public void Post([FromBody]Todo todo)
        {
            _todoRepository.AddTodo(todo);
        }

        // PUT api/todos/{id}
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Todo todo)
        {
            _todoRepository.UpdateTodoDocument(new ObjectId(id), todo);
        }

        // DELETE api/todos/{id}
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _todoRepository.RemoveTodo(new ObjectId(id));
        }

        // DELETE api/todos/removeall
        [Route("todos/removeall")]
        [HttpGet]
        public string DeleteAll()
        {
            _todoRepository.RemoveAllTodos();
            return "done";
        }
    }
}
