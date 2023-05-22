namespace Tax.API.Business_Rules;

public class FlatValueTax : ITaxBase
{
    //Threshold is set. income above, will be taxed by fixed amount. income below will be taxed by percentage
    //AboveThresholdTaxAmount  value is fixed
    //BelowThresholdTaxPerc Percentage to be taxed off income
    private readonly (int Threshold, int AboveThresholdTaxAmount, decimal BelowThresholdTaxPerc) Rate = (200000, 10000 , 5m);

    public decimal Calculate(decimal income)
    {
        if (income < Rate.Threshold)
            return (income * Rate.BelowThresholdTaxPerc) / 100;
        else
            return Convert.ToDecimal(Rate.AboveThresholdTaxAmount);
    }
}

