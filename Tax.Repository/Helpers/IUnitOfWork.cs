namespace Tax.Repository.Helpers;

public interface IUnitOfWork
{
    ITaxRepository TaxRepository { get; }

    Task<int> Complete();

}
