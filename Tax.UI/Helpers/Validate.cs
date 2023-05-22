using System.Reflection;
using System.Text.RegularExpressions;

namespace Tax.UI.Helpers;

public static class Validate
{
    public static bool AnnualIncome(decimal AnnualIncome)
    {
        Regex regexDigits = new Regex("^[0-9]*$");
        return regexDigits.IsMatch(AnnualIncome.ToString());
    }

    public static bool PostalCode(string PostalCode)
    {
        if (string.IsNullOrEmpty(PostalCode))
            return false;

        string code = PostalCode.Trim();
        if (code == "7441" ||
            code == "A100" ||
            code == "7000" ||
            code == "1000")
        {
            return true;
        }
        else
            return false;
    }
}

