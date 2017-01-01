using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace dotnet_core_api.Controllers
{
    [EnableCors("CorsPolicy")]
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
        [HttpGet("{id}", Name="GetTodo")]
        public async Task<Todo> Get(string id)
        {
            return await _todoRepository.GetTodo(new ObjectId(id)) ?? new Todo();
        }

        // POST api/todos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Todo todo)
        {
            await _todoRepository.AddTodo(todo);
            return CreatedAtRoute("GetTodo", new {id = todo.Id}, todo);
        }

        // PUT api/todos/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody]Todo todo)
        {
            await _todoRepository.UpdateTodoDocument(new ObjectId(id), todo);
            return new NoContentResult();
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
