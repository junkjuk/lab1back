using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace lab1back.Models;

public class Bill : EntityId
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public float Balance { get; set; }

    [JsonIgnore]
    public virtual User? User { get; set; }
}