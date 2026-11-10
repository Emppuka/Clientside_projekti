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

    public TodoViewModel(TodoService todoService)
    {
        _todoService = todoService;
    }

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
}