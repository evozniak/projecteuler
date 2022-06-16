using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace projecteuler
{
    /// <summary>
    //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary> 
    public class Exercise5 : ICommand
    {
        private readonly ILogger _logger;

        public Exercise5(ILogger logger)
        {
            this._logger = logger;
        }

        public string Resolve()
        {
            int number = 20;
            do
            {
                number++;                
            } while (!isDivisibleByNumbers1To20(1,20,number));
            return number.ToString();
        }

        private bool isDivisibleByNumbers1To20(int initialRange, int finalRange, int number)
        {
            for (int i = initialRange; i < finalRange; i++)
            {
                bool isFloat = number % i != 0;
                if (isFloat)
                    return false;
            }
            return true;
        }

    }
}
