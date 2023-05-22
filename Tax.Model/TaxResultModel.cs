using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tax.Model;

/*
Model mainly for UI. But is also used in other areas of the system, like posting to API
Note: Attribute Decorators used on properties
*/

public class TaxResultModel
{
    [Required(ErrorMessage = "Annual Income is Required!")]
    [Display(Name = "Annual Income")]
    public decimal AnnualIncome { get; set; }

    [Required(ErrorMessage = "Postal Code is Required!")]
    [Display(Name = "Postal Code")]
    [MaxLength(4)]
    public string PostalCode { get; set; }

    [Display(Name = "Result")]
    public decimal Result { get; set; }

    public DateTime DateTime { get; set; } = DateTime.Now;

    public bool HasResult { get; set; } = false;
}