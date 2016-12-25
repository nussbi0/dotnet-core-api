using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;
using MongoDB.Bson;

namespace dotnet_core_api.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context = null;

        public TodoRepository(IOptions<Settings>settings)
        {
            _context = new TodoContext(settings);
        }

        public async Task AddTodo(Todo item)
        {
            await _context.Todos.InsertOneAsync(item);
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            try
            {
                return await _context.Todos.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task<Todo> GetTodo(string id)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteResult> RemoveAllTodos()
        {
            throw new NotImplementedException();
        }

        public Task<DeleteResult> RemoveTodo(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateResult> UpdateTodo(string id, string text)
        {
            throw new NotImplementedException();
        }

        public Task<ReplaceOneResult> UpdateTodoDocument(string id, string text)
        {
            throw new NotImplementedException();
        }
    }
}