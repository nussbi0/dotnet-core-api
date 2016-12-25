using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_api.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Todo>> Get()
        {
            return GetTodoInternal();
        }

        private async Task<IEnumerable<Todo>> GetTodoInternal()
        {
            return await _todoRepository.GetAllTodos();
        }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody]string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody]string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
