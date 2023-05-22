using Tax.Model;
using Tax.Services;
using Tax.Services.Helpers;

namespace Tax.Services;

public class TaxResultService : BaseService<TaxResultModel>, ITaxResultService
{
    //make sure apiName contains a forward slash at the end.
    public TaxResultService(string baseUrl) : base(baseUrl, "TaxResult/")
    {
    }
}
