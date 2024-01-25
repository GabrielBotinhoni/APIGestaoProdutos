
using System.Text.RegularExpressions;

public class ValidacaoUtil
{

    public static bool ValidaMascaraCNPJ(string cnpj)
    {
        if(!string.IsNullOrWhiteSpace(cnpj))
        {
           return Regex.IsMatch(cnpj, "^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$");
        }
        return true;
    }
}
