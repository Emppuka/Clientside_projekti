using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementApp.Models;
using LifeManagementApp.Services;
using System.Collections.ObjectModel;
using System.Linq;


namespace LifeManagementApp.ViewModels;

public partial class TodoViewModel : ObservableObject
{
    private readonly TodoService _todoService;
    public ObservableCollection<TodoItem> Todos { get; } = new();
    [ObservableProperty]
    private string newTodoTitle = string.Empty;


    [RelayCommand]
    private void AddTodo()
    {
        if (string.IsNullOrWhiteSpace(NewTodoTitle))
            return;

        TodoItem todo = new TodoItem
        {
            Title = NewTodoTitle,
            Priority = SelectedPriority
        };

        _todoService.AddTodo(todo);

        Todos.Add(todo);
        SortTodos();

        NewTodoTitle = string.Empty;
    }
    [ObservableProperty]
    private int selectedPriority = 1;

    [RelayCommand]
    private void DeleteTodo(TodoItem todo)
    {
        _todoService.DeleteTodo(todo);

        Todos.Remove(todo);
    }

    private void SortTodos()
    {
        List<TodoItem> sortedTodos = Todos
            .OrderBy(todo => todo.Priority)
            .ToList();

        Todos.Clear();

        foreach (TodoItem todo in sortedTodos)
        {
            Todos.Add(todo);
        }
    }

    public TodoViewModel(TodoService todoService)
    {
        _todoService = todoService;

        List<TodoItem> todos = _todoService.GetTodos();

        foreach (TodoItem todo in todos)
        {
            Todos.Add(todo);
        }
    }
}