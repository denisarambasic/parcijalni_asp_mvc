using AspNet.TODO.Models;

namespace AspNet.TODO.Repository;

public interface ITodoRepository
{
    List<Todo> GetTodoList();
}
