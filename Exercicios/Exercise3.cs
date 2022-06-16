using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace projecteuler
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    ///What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    public class Exercise3 : ICommand
    {
        private readonly ILogger _logger;

        public Exercise3(ILogger logger)
        {
            this._logger = logger;
        }

        public string Resolve()
        {
            var result = CalculatePrimeFactor(600_851_475_143);
            return result.ToString();
        }

        private int CalculatePrimeFactor(long number)
        {
            int currentDivider = 2;
            decimal currentNumber = number;            
            List<int> primeNumbers = new List<int>();
            while(currentNumber != 1)
            {
                decimal reminder = currentNumber / currentDivider;
                bool isInteger = reminder % 1 == 0;
                if (isInteger)
                {
                    primeNumbers.Add(currentDivider);
                    currentNumber = reminder;
                }
                else
                {
                    currentDivider++;
                }
            }
            return primeNumbers.LastOrDefault();
        }
    }
}
