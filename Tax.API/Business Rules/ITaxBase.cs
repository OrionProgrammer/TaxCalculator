namespace Tax.API.Business_Rules;

public interface ITaxBase
{
    public decimal Calculate(decimal income);
}

