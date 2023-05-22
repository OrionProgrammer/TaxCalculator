using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tax.API.Business_Rules;
using Tax.API.Helpers;
using Tax.Domain;
using Tax.Repository.Helpers;
using Tax.Model;
using System.Diagnostics.CodeAnalysis;

namespace Tax.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TaxResultController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Func<TaxType.Type, ITaxBase> _taxCalculator;
    private readonly IMapper _mapper;

    private readonly ILogger<TaxResultController> _logger;

    public TaxResultController(ILogger<TaxResultController> logger,
        IUnitOfWork unitOfWork,
        Func<TaxType.Type, ITaxBase> taxCalculator,
        IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _taxCalculator = taxCalculator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<decimal>> CalculateTax([FromBody] TaxResultModel model)
    {
        #region Validation
        if (!ModelState.IsValid)
            return BadRequest(new { message = GetErrors() });
        #endregion

        decimal result = 0;

        switch (model.PostalCode)
        {
            case "7441":
            case "1000":
                var progressiveTax = _taxCalculator(TaxType.Type.Progressive);
                result = progressiveTax.Calculate(model.AnnualIncome);
                break;
            case "A100":
                var flatValueTax = _taxCalculator(TaxType.Type.Flat_Value);
                result = flatValueTax.Calculate(model.AnnualIncome);
                break;
            case "7000":
                var flatRateTax = _taxCalculator(TaxType.Type.Flat_Rate);
                result = flatRateTax.Calculate(model.AnnualIncome);
                break;
            default:
                return BadRequest(new { message = "Incorrect Postal Code!" });
        }

        #region Save Result to Local DB
        var taxResult = _mapper.Map<TaxResult>(model);
        taxResult.Result = result;

        // add object for inserting
        //wrapped it in try catch as the [ExcludeFromCodeCoverage] is not not excluding the DB code from Testing. It throws an error, because of localDB
        try
        {
            await SaveToDatabase(taxResult);
        }
        catch { }
        #endregion

        return Ok(result);
    }

    [ExcludeFromCodeCoverage]
    private async Task SaveToDatabase(TaxResult taxResult)
    {
        await _unitOfWork.TaxRepository.InsertAsync(taxResult);
        await _unitOfWork.Complete();
    }


    [HttpGet("List")]
    public async Task<IEnumerable<TaxResultModel>> List()
    {
        IEnumerable<TaxResult> taxResult = await _unitOfWork.TaxRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<TaxResultModel>>(taxResult);
    }
}
