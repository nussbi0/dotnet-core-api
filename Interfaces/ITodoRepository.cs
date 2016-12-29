using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_core_api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace dotnet_core_api.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodo(ObjectId id);
        Task AddTodo(Todo item);
        Task<DeleteResult> RemoveTodo(ObjectId id);
        Task<ReplaceOneResult> UpdateTodoDocument(ObjectId id, Todo todo);
        Task<DeleteResult> RemoveAllTodos();
    }
}