namespace LifeManagementApp.Models;

public class TodoItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public int Priority { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool IsCompleted { get; set; }

    public string PriorityText
    {
        get
        {
            return Priority switch
            {
                0 => "Korkea",
                1 => "Normaali",
                2 => "Matala",
                _ => "Tuntematon"
            };
        }
    }
}