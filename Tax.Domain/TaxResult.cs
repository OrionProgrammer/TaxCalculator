using System.ComponentModel.DataAnnotations;

namespace Tax.Domain;

public class TaxResult
{
    [Key]
    public int Id { get; set; }

    [DataType("decimal(18,5)")]
    public decimal AnnualIncome { get; set; }

    public string PostalCode { get; set; }

    [DataType("decimal(18,5)")]
    public decimal Result { get; set; }

    public DateTime DateTime { get; set; } = DateTime.Now;
}
