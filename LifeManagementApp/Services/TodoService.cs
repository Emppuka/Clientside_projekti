using LifeManagementApp.Data;
using LifeManagementApp.Models;

namespace LifeManagementApp.Services;

public class TodoService
{
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public List<TodoItem> GetTodos()
    {
        return _context.Todos.ToList();
    }

    public void AddTodo(TodoItem todo)
    {
        _context.Todos.Add(todo);

        _context.SaveChanges(); //TÄRKEÄ -> ilman tätä ei tallennu tietokantaan
    }
}