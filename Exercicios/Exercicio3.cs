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
    public class Exercicio3 : ICommand
    {
        //TODO - Finalizar exercício.
        private readonly ILogger _logger;
        public Exercicio3(ILogger logger)
        {
            this._logger = logger;
        }

        public string Resolve()
        {
            int goal = Convert.ToInt32(600_851_475_143 / 4000);
            var primeNumbers = GeneratePrimeNumbers(10000);
            foreach (var item in primeNumbers)
            {
                _logger.Information(item.ToString());
            }
            return "";
        }

        private List<int> GeneratePrimeNumbers(int numeroMaximo)
        {
            var output = new List<int>();

            for (int number = 2; number < numeroMaximo; number++)
            {
                if (IsPrimeNumber(number))
                    output.Add(number);
            }
            return output;
        }

        private static bool IsPrimeNumber(int number)
        {
            var halfMaximum = number / 2;
            for (int factor1 = 2; factor1 <= halfMaximum; factor1++)
            {
                if (number % factor1 == 0)
                    return false;
            }
            return true;

        }
    }
}
