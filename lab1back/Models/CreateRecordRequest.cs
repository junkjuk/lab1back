namespace lab1back.Models;

public class CreateRecordRequest
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public float Amount { get; set; }
}