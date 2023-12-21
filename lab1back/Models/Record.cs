﻿using System.Text.Json.Serialization;

namespace lab1back.Models;

public class Record : EntityId
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public float Amount { get; set; }
    [JsonIgnore]
    public virtual User? User { get; set; }
    [JsonIgnore]
    public virtual Category? Category { get; set; }
    
    public Record() {}

    public Record(CreateRecordRequest req)
    {
        UserId = req.UserId;
        CategoryId = req.CategoryId;
        Amount = float.Parse(req.Amount);
        CreatedAt = DateTime.Now;
        Id = Guid.NewGuid();
    }
}