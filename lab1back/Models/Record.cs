namespace lab1back.Models;

public class Record
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public float Amount { get; set; }

    public Record(CreateRecordRequest req)
    {
        UserId = req.UserId;
        CategoryId = req.CategoryId;
        Amount = req.Amount;
        CreatedAt = DateTime.Now;
        Id = Guid.NewGuid();
    }
}