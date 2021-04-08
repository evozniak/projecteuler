using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecteuler
{
    public class ExercicioBase
    {
        public ILog Log { get; init; }

        public ExercicioBase(ILog log)
        {
            Log = log;
        }
    }
}
