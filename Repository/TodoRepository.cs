using AspNet.TODO.Models;

namespace AspNet.TODO.Repository;

public class TodoRepository : ITodoRepository
{
    //simulacija baze podataka
    private static List<Todo>? _todoList;

    public TodoRepository()
    {
        if (_todoList == null)
        {
            _todoList =
            [
                new() { Id = 1, Title = "Kupiti Kruh", IsCompleted = true },
                new() { Id = 2, Title = "Kupiti Sok", IsCompleted = true },
                new() { Id = 3, Title = "Kupiti Meso", IsCompleted = true },
                new() { Id = 4, Title = "Napraviti ručak", IsCompleted = false },
                new() { Id = 5, Title = "Natočiti gorivo", IsCompleted = false }
            ];
        }
    }

    public List<Todo> GetTodoList()
    {
        return _todoList!;
    }
}
