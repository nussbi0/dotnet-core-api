using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_core_api.Models;
using MongoDB.Driver;

namespace dotnet_core_api.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodo(string id);
        Task AddTodo(Todo item);
        Task<DeleteResult> RemoveTodo(string id);

        Task<UpdateResult> UpdateTodo(string id, string text);

        // demo interface - full document update
        Task<ReplaceOneResult> UpdateTodoDocument(string id, string text);

        // should be used with high cautious, only in relation with demo setup
        Task<DeleteResult> RemoveAllTodos();
    }
}