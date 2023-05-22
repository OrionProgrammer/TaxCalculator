namespace Tax.Repository.Helpers;

using System;
using Tax.Domain;
using System.Threading.Tasks;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public ITaxRepository TaxRepository{ get; }

    public UnitOfWork(DataContext dataContext,
        ITaxRepository taxRepository)
    {
        this._context = dataContext;
        this.TaxRepository = taxRepository;
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}