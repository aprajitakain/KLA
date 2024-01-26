using Microsoft.AspNetCore.Mvc;
using KLA.Model;



[Route("api/currencyconverter")]
[ApiController]
public class CurrencyConverterController : Controller
{
    [HttpGet]
    public ActionResult<string> ConvertToWords([FromQuery] CurrencyRequest request)
    {
        try
        {
            string result = ConvertToWords(request.Amount);
            if (result.Contains("Invalid Number"))
            {

                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"Error converting amount: {ex.Message}");
        }
    }

    private string ConvertToWords(string currencyAmount)
    {
        string[] parts = currencyAmount.Split(',');

        // Count the separator
        long separatorCount = parts.Length - 1;

        if (separatorCount == 1)
        {
            long digit1 = int.Parse(parts[0]);
            long digit2 = int.Parse(parts[1]);
            if (digit1 == 0)
            {
                if (digit2 == 0)
                {
                    return "zero dollars";
                }
                else if (digit2 > 0 && digit2 < 100)
                {
                    string result2 = ConvertToWordsHelper(digit2);
                    return $"{result2} cents";
                }
                else
                {
                    return "Invalid Number - 99 cents is max";
                }
            }
            else if (digit1 > 0 && digit1 <= 999999999)
            {
                string result1 = ConvertToWordsHelper(digit1);

                if (digit2 == 0)
                {
                    return $"{result1} dollars";
                }
                else if (digit2 > 0 && digit2 < 100)
                {
                    string result2 = ConvertToWordsHelper(digit2);
                    return $"{result1} dollars and {result2} cents";
                }
                else
                {
                    return "Invalid Number - 99 cents is max";
                }
            }
            else
            {
                return "Invalid Number - 999 999 999 dollars is max";
            }
        }
        else if (separatorCount == 0)
        {
            // Extract single digit
            long singleDigit = long.Parse(currencyAmount);
            if (singleDigit == 0)
            {
                return "zero dollars";
            }
            else if (singleDigit > 0 && singleDigit <= 999999999)
            {
                return $"{ConvertToWordsHelper(singleDigit)} dollars";
            }
            else
            {
                return "Invalid Number - 999 999 999 dollars is max";
            }
        }
        else
        {
            return "Invalid Number - Zero or one comma(separator)";
        }
    }

    private string ConvertToWordsHelper(long number)
    {
        string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] teens = { "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        if (0 < number && number < 10)
        {
            return units[number];
        }
        else if (10 == number)
        {
            return tens[1];
        }
        else if (10 < number && number < 20)
        {
            return teens[number - 10];
        }
        else if (20 <= number && number < 100)
        {
            return $"{tens[number / 10]}{(number % 10 != 0 ? "-" + units[number % 10] : "")}";
        }
        else if (100 <= number && number < 1000)
        {
            return $"{units[number / 100]} hundred {ConvertToWordsHelper(number % 100)}";
        }
        else if (1000 <= number && number < 1000000)
        {
            return $"{ConvertToWordsHelper(number / 1000)} thousand {ConvertToWordsHelper(number % 1000)}";
        }
        else if (1000000 <= number && number < 1000000000)
        {
            return $"{ConvertToWordsHelper(number / 1000000)} million {ConvertToWordsHelper(number % 1000000)}";
        }
        else
        {
            return "";
        }
    }
}

