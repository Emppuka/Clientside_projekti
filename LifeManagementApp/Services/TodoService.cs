using LifeManagementApp.Data;
using LifeManagementApp.Models;

namespace LifeManagementApp.Services;

public class TodoService
{

    public event Action? TodosChanged;

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

        TodosChanged?.Invoke();
    }

    public void DeleteTodo(TodoItem todo)
    {
        _context.Todos.Remove(todo);

        _context.SaveChanges();

        TodosChanged?.Invoke();
    }

    public void UpdateTodo(TodoItem todo)
    {
        _context.Todos.Update(todo);

        _context.SaveChanges();

        TodosChanged?.Invoke();
    }

}