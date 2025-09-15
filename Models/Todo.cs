using System.ComponentModel.DataAnnotations;

namespace AspNet.TODO.Models;

public class Todo
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool IsCompleted { get; set; }
}
