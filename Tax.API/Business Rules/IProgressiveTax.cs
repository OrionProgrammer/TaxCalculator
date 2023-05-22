namespace Tax.API.Business_Rules;

public interface IProgressiveTax
{
    //'init' instead of 'set' used, to initialize the tuple array just once.
    public (int Percentage, int From, int To) [] Rate { get; init; }
}

