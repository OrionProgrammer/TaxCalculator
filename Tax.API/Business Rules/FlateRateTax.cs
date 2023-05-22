namespace Tax.API.Business_Rules;

public class FlateRateTax : ITaxBase
{
    private readonly decimal Rate = 17.5m;

    public decimal Calculate(decimal income)
    {
        return (income * Rate) / 100;
    }
}

