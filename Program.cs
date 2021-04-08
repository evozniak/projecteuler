using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace projecteuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var executor = new Executor();
            executor.ExecutarTodos();

            //executor.ObterResposta(typeof(Exercicio1));
            //Console.WriteLine(executor.ObterTodasRespostas());
        }
    }
}
