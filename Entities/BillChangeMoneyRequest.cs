namespace Entities;

public class BillChangeMoneyRequest
{
    public Guid UserId { get; set; }
    public float Money { get; set; }
}