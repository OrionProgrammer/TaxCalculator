namespace Tax.API.Helpers;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class BaseController : ControllerBase
{

    [NonAction]
    public string GetErrors()
    {
        return string.Join("; ", ModelState.Values
                               .SelectMany(x => x.Errors)
                               .Select(x => x.ErrorMessage));
    }
}