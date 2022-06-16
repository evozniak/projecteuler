using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace projecteuler
{
    /// <summary>
    //A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    //Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    public class Exercise4 : ICommand
    {
        private readonly ILogger _logger;

        public Exercise4(ILogger logger)
        {
            this._logger = logger;
        }

        public string Resolve()
        {
            var result = 0;
            for (int factor1 = 999; factor1 > 0; factor1--)
            {
                for (int factor2 = 999; factor2 > 0; factor2--)
                {
                    var calculation = factor1 * factor2;
                    if (IsPalindromeNumber(calculation) && calculation > result)
                    {
                        result = calculation;
                    }
                }
            }
            return result.ToString();
        }

        private bool IsPalindromeNumber(long number)
        {
            string reverted = new string(number.ToString().ToCharArray().Reverse().ToArray());
            return reverted == number.ToString();
        }
    }
}
