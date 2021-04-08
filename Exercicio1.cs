using System.Collections.Generic;
using System.Linq;

namespace projecteuler
{
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    ///  Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    public class Exercicio1 : IComando
    {

        public void Executar()
        {
            System.Console.WriteLine("Soma de valores múltiplos de 3 e 5 até 1000");
            var numeros = new List<long>();
            for (int i = 1; i < 1000; i++)
            {
                var ehMultipoDeTres = i % 3 == 0;
                var ehMultipoDeCinco = i % 5 == 0;
                if (ehMultipoDeTres || ehMultipoDeCinco)
                    numeros.Add(i);
            }
            var soma = numeros.Sum();
            System.Console.WriteLine(soma);
        }

    }
}