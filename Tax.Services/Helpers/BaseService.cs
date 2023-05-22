namespace Tax.Services.Helpers;

/*
 This is a trimmed down version of my generic HTTP Service
 */

public class BaseService<T> where T : class
{
    private string _apiName;
    private HttpClient client;

    ~BaseService()
    {
        client.Dispose();
    }

    public BaseService(string baseUrl, string apiName)
    {
        _apiName = apiName;

        client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
    }

    /// <summary>
    /// Posts to the API
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>A tuple type is returned.  (bool, HttpContent) </returns>
    public virtual async Task<(bool Success, HttpContent Content)> PostAsync(T entity)
    {
        var response = await client.PostAsJsonAsync(_apiName, entity);

        return (response.IsSuccessStatusCode, response.Content);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        var entities = new List<T>();

        var response = await client.GetAsync(_apiName + "list");

        if (response.IsSuccessStatusCode)
            entities = await response.Content.ReadAsAsync<List<T>>();

        return entities;
    }
}
