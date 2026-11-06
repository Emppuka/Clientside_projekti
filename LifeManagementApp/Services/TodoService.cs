using LifeManagementApp.Models;

namespace LifeManagementApp.Services;

public class TodoService
{
    private readonly List<TodoItem> _todos = new();

    public List<TodoItem> GetTodos()
    {
        return _todos;
    }

    public void AddTodo(TodoItem todo)
    {
        _todos.Add(todo);
    }
}