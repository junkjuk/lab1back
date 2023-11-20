namespace lab1back;

public class HealthcheckResponse
{
    public DateTime Date { get; set; }
    public string Status { get; set; }

    public HealthcheckResponse(string status)
    {
        Status = status;
        Date = DateTime.Now;
    }
}