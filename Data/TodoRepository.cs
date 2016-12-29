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

        public TodoRepository(IOptions<Settings> settings)
        {
            _context = new TodoContext(settings);
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            try
            {
                return await _context.Todos.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Todo> GetTodo(ObjectId id)
        {
            try
            {
                return await _context.Todos.Find(Builders<Todo>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task AddTodo(Todo item)
        {
            try
            {
                await _context.Todos.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeleteResult> RemoveTodo(ObjectId id)
        {
            try
            {
                return await _context.Todos.DeleteOneAsync(Builders<Todo>.Filter.Eq("Id", id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ReplaceOneResult> UpdateTodoDocument(ObjectId id, Todo todo)
        {
            var item = await GetTodo(id) ?? new Todo();
            item.task = todo.task;
            item.done = todo.done;
            item.dueDate = todo.dueDate;
            item.UpdatedOn = DateTime.Now;

            try
            {
                return await _context.Todos.ReplaceOneAsync(n => n.Id.Equals(id), item, new UpdateOptions { IsUpsert = true });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeleteResult> RemoveAllTodos()
        {
            try
            {
                return await _context.Todos.DeleteManyAsync(new BsonDocument());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}