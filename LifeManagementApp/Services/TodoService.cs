using LifeManagementApp.Data;
using LifeManagementApp.Models;
using Microsoft.EntityFrameworkCore;

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
        return _context.Todos
            .AsNoTracking()
            .ToList();
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
        TodoItem? existingTodo =
            _context.Todos.FirstOrDefault(t => t.Id == todo.Id);

        if (existingTodo == null)
            return;

        existingTodo.Title = todo.Title;
        existingTodo.Priority = todo.Priority;
        existingTodo.IsCompleted = todo.IsCompleted;

        _context.SaveChanges();

        TodosChanged?.Invoke();
    }


}