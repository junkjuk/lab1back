using System.Text.Json.Serialization;

namespace Entities;

public class User : EntityId
{
    public string Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<Record>? Records { get; set; }
    [JsonIgnore]
    public virtual Bill? Bill { get; set; }
}