using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Tax.Model;
using Tax.Services;
using Tax.UI.Helpers;

namespace Tax.UI.Controllers
{
    public class Tax : Controller
    {
        private readonly ITaxResultService _taxResultService;

        public Tax(ITaxResultService taxResultService)
        {
            _taxResultService = taxResultService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //create the model to send back to view
            TaxResultModel model = new TaxResultModel();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(TaxResultModel model)
        {
            #region Validation
            /*Manual validation as RegularExpression Attribute caused a bug on my Model when posting JSON to API. So doing it here :( .*/

            ModelState.Clear();

            if (Validate.AnnualIncome(model.AnnualIncome) == false)
                ModelState.AddModelError("AnnualIncome", "Please enter numbers only!");

            if (model.AnnualIncome == 0)
                ModelState.AddModelError("AnnualIncome", "Please enter your Annual Income!");

            if (Validate.PostalCode(model.PostalCode) == false)
                ModelState.AddModelError("PostalCode", "Please enter a valid Postal Code!");

            model.HasResult = ModelState.IsValid;

            if (!ModelState.IsValid)
                return View(model);
            #endregion

            var response = await _taxResultService.PostAsync(model);

            if (response.Success)
                model.Result = await response.Content.ReadAsAsync<decimal>();

            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> History()
        {
            var list = await _taxResultService.GetAllAsync();
            return View(list);
        }
    }
}
