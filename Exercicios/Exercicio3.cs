using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecteuler.Exercicios
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    ///What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    public class Exercicio3 : ExercicioBase, IComando
    {
        //TODO - Finalizar exercício.
        public Exercicio3(ILog log) : base(log) { }

        public string Resolver()
        {
            int meta = Convert.ToInt32(600_851_475_143 / 4000);
            var numerosPrimos = GerarNumerosPrimos(10000);
            foreach (var item in numerosPrimos)
            {
                Console.WriteLine(item);
            }
            return "";
        }

        private List<int> GerarNumerosPrimos(int numeroMaximo)
        {
            var saida = new List<int>();

            for (int numero = 2; numero < numeroMaximo; numero++)
            {
                if (EhUmNumeroPrimo(numero))
                    saida.Add(numero);
            }
            return saida;
        }

        private static bool EhUmNumeroPrimo(int numero)
        {
            var metadeMaximo = numero / 2;
            for (int fator1 = 2; fator1 <= metadeMaximo; fator1++)
            {
                if (numero % fator1 == 0)
                    return false;
            }
            return true;

        }
    }
}
