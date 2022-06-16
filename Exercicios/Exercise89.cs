using System;
using System.Collections.Generic;
using System.IO;
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
    public class Exercise89 : ICommand
    {
        //TODO
        private readonly ILogger _logger;

        public Exercise89(ILogger logger)
        {
            this._logger = logger;
        }

        public string Resolve()
        {
            var lines = File.ReadLines("TextFiles/p089_roman.txt");
            foreach (var line in lines)
            {
                System.Console.WriteLine(line);
            }
            return "";
        }

        private int RomanToInt(string romanNumber)
        {
            
            return 0;
        }
    }
}
