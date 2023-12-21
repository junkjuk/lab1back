using System.Text.Json.Serialization;

namespace Entities;

public class Category : EntityId
{
    public string Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<Record>? Records { get; set; }
}