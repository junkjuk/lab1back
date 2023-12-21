using System.Text.Json.Serialization;

namespace lab1back.Models;

public class Category : EntityId
{
    public string Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<Record>? Records { get; set; }
}