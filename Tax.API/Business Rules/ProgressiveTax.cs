namespace Tax.API.Business_Rules;

public class ProgressiveTax : IProgressiveTax, ITaxBase
{
    //'init' instead of 'set' used, to initialize the tuple array just once.
    public (int Percentage, int From, int To)[] Rate { get; init; }

    public ProgressiveTax()
    {
        //initialize the Tuple Array with Progressive Tax Rates
        Rate = new (int, int, int)[]
        {
            new ( 10, 0, 8350),
            new ( 15, 8351, 33950),
            new ( 25, 33951, 82250),
            new ( 28, 82251, 171550),
            new ( 33, 171551, 372950),
            new ( 35, 372951, 372951), //note, if both From and To are equal, then tax is calculated above the value.
        };
    }

    public virtual decimal Calculate(decimal income)
    {
        decimal taxResult = 0m;

        foreach (var rate in Rate)
        {
            if (income > rate.From - 1)
            {
                var amountToTax = Math.Min(rate.To - rate.From, income - rate.From);
                var tax = (amountToTax * rate.Percentage) / 100;
                taxResult += tax;
            }
        }

        return taxResult;
    }
}

