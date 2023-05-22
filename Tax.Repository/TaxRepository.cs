using Tax.Domain;
using Tax.Repository;
using Tax.Repository.Helpers;

namespace Tax.Repository;

public class TaxRepository : GenericRepository<TaxResult>, ITaxRepository
{
    public TaxRepository(DataContext context) : base(context) { }

}
