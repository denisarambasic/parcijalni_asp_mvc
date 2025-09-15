using AspNet.TODO.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.TODO.Controllers;

public class TodoController : Controller
{
    private readonly ITodoRepository _todoRepository;

    public TodoController(ITodoRepository todoRepository)
    {
        if(todoRepository == null) throw new ArgumentNullException(nameof(todoRepository));
        _todoRepository = todoRepository;
    }

    public IActionResult Index()
    {
        return View(_todoRepository.GetTodoList());
    }
}
