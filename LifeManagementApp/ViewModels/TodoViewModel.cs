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

       List<TodoItem> todos = _todoService.GetTodos();

        foreach (TodoItem todo in todos)
        {
            Todos.Add(todo);
        }
    }

    [ObservableProperty]
    private TodoItem? selectedTodo;



    private void ReloadTodos()
    {
        List<TodoItem> todos = _todoService
            .GetTodos()
            .OrderBy(t => t.Priority)
            .ToList();

        Todos.Clear();

        foreach (TodoItem todo in todos)
        {
            Todos.Add(todo);
        }

        OnPropertyChanged(nameof(Todos));
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

        ReloadTodos();

        NewTodoTitle = string.Empty;
    }
    [ObservableProperty]
    private int selectedPriority = 1;

    [RelayCommand]
    private void DeleteTodo(TodoItem todo)
    {
        _todoService.DeleteTodo(todo);

        ReloadTodos();
    }

    [RelayCommand]
    private void EditTodo(TodoItem todo)
    {
        SelectedTodo = todo;

        NewTodoTitle = todo.Title;

        SelectedPriority = todo.Priority;
    }

    
    [RelayCommand]
    private void SaveChanges()
    {
        if (SelectedTodo == null)
            return;

        SelectedTodo.Title = NewTodoTitle;
        SelectedTodo.Priority = SelectedPriority;

        _todoService.UpdateTodo(SelectedTodo);

        SelectedTodo = null;

        NewTodoTitle = string.Empty;

        SelectedPriority = 1;

        ReloadTodos();
    }

    private void SortTodos()
    {
        List<TodoItem> sortedTodos = _todoService
            .GetTodos()
            .OrderBy(todo => todo.Priority)
            .ToList();

        Todos.Clear();

        foreach (TodoItem todo in sortedTodos)
        {
            Todos.Add(todo);
        }
    }

}