using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities;

public class Category : EntityId
{
    [Required]
    public string Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<Record>? Records { get; set; }
}