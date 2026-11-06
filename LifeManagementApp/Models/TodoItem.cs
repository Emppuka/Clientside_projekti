namespace LifeManagementApp.Models;

public class TodoItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public int Priority { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool IsCompleted { get; set; }
}