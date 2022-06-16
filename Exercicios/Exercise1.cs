using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace projecteuler
{
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    ///  Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    public class Exercise1 : ICommand
    {
        private readonly ILogger _logger;
        public Exercise1(ILogger logger)
        {
            this._logger = logger;
        }

        public string Resolve()
        {
            _logger.Information("Sums values multiple of 3 and 5 until 1000");
            var numbers = new List<long>();
            for (int i = 1; i < 1000; i++)
            {
                var isMultipleOfThree = i % 3 == 0;
                var isMultipleOfFive = i % 5 == 0;
                if (isMultipleOfThree || isMultipleOfFive)
                    numbers.Add(i);
            }
            var sum = numbers.Sum();
            Log.Information(sum.ToString());
            return sum.ToString();
        }
    }
}