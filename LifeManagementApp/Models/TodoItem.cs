namespace LifeManagementApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class TodoItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public int Priority { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool IsCompleted { get; set; }

    [NotMapped]
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

    [NotMapped]
    public bool IsEditing { get; set; } // Tällä seurataan onko tehtävä muokkaustilassa
}