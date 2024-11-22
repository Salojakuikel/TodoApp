using TODOApp.Data;
using TODOApp.Models;
using TODOApp.Repositories.Interfaces;

namespace TODOApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public List<TodoDto> GetAll()
        {
            var todos = Database.Todos.ToList();
            return todos;
        }
        public TodoDto GetbyId(Guid id)
        {
            return Database.Todos.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(Guid id)
        {
            var todo = Database.Todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                Database.Todos.Remove(todo);
            }
        }
    }
}
