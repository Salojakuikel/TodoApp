using Microsoft.AspNetCore.Mvc;
using TODOApp.Data;
using TODOApp.Models;
using TODOApp.Repositories.Interfaces;

using TODOApp.Services.Interfaces;

namespace TODOApp.Controllers
{
    public class TodoController : Controller
    {
        public TodoController(
            ITodoService todoService,
            ITodoRepository todoRepository
            )
        {
            _todoService = todoService;
            _todoRepository = todoRepository;
        }

        public ITodoService _todoService { get; }
        public ITodoRepository _todoRepository { get; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TodoVm vm)
        {
           
            var dto = new TodoDto();
            dto.TaskTitle = vm.TaskTitle;
            dto.TaskDescription = vm.TaskDescription;

            
            _todoService.Create(dto);

            return RedirectToAction("Index");
        }

        public IActionResult GetTodos()
        {
            var todos = _todoRepository.GetAll();
            return View(todos);
        }


        [HttpPost]
        public IActionResult Update(Guid id, TodoDto dto)
        {
            var todo = Database.Todos.FirstOrDefault(t => t.Id == id);
            todo.TaskTitle = dto.TaskTitle;
            todo.TaskDescription = dto.TaskDescription;
            todo.TaskDate = dto.TaskDate;
            return RedirectToAction("GetTodos");

        }

        public IActionResult Update(Guid id)
        {
            var todo = Database.Todos.FirstOrDefault(t => t.Id == id);
            return View(todo);
        }
        
        public IActionResult Delete(Guid id, TodoDto dto)
        {
            var todo = Database.Todos.FirstOrDefault(t => t.Id == id);
            todo.TaskTitle = dto.TaskTitle;
            todo.TaskDescription = dto.TaskDescription;
            todo.TaskDate = dto.TaskDate;
            return RedirectToAction("GetTodos");
            return View(todo);

        }

    }
    
}
