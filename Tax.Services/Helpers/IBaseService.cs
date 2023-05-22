
namespace Tax.Services.Helpers;

public interface IBaseService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<(bool Success, HttpContent Content)> PostAsync(T entity);

}

