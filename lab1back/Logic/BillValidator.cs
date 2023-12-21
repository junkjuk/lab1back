using Entities;

namespace lab1back.Logic;

public static class BillValidator
{
    public static void ValidateBill(Bill bill)
    {
        if (bill.Balance < -1000)
            throw new Exception("Balance must be more than -1000");

        if (bill.Balance > 100000)
            throw new Exception("Balance must be less than 100000");
    }
}