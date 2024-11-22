using TODOApp.Models;

namespace TODOApp.Data
{
    public static class Database
    {
        public static List<TodoDto> Todos { get; } = new List<TodoDto>();
    }
}
