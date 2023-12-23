using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities;

public class User : EntityId
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
    [JsonIgnore]
    public virtual ICollection<Record>? Records { get; set; }
    [JsonIgnore]
    public virtual Bill? Bill { get; set; }
}