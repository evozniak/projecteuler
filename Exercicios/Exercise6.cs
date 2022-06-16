using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace projecteuler
{
    /// <summary>
    //The sum of the squares of the first ten natural numbers is,
    //The square of the sum of the first ten natural numbers is,
    //Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is .
    //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary> 
    public class Exercise6 : ICommand
    {
        private readonly ILogger _logger;

        public Exercise6(ILogger logger)
        {
            this._logger = logger;
        }

        public string Resolve()
        {
            var sumOfSquares = SumOfSquares(100);
            var squareOfSum = SquareOfTheSum(100);
            var result = squareOfSum - sumOfSquares;
            return result.ToString();
        }

        private double SumOfSquares(int range)
        {
            double result = 0;
            for (int i = 1; i <= range; i++)
            {
                result += Math.Pow(i, 2);
            }
            return result;
        }

        private double SquareOfTheSum(int range)
        {
            double result = 0;
            for (int i = 1; i <= range; i++)
            {
                result += i;
            }
            return Math.Pow(result, 2);
        }

    }
}
