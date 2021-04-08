using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace projecteuler
{
    public class Executor
    {
        private List<IComando> Exercicios { get; init; }

        public Executor()
        {
            Exercicios = new List<IComando>();

            IEnumerable<Type> classes = BuscarClassesImplementandoInterface();

            foreach (var classe in classes)
            {
                var objeto = Activator.CreateInstance(classe);
                IComando comando = objeto as IComando;
                Exercicios.Add(comando);
            }
        }

        private static IEnumerable<Type> BuscarClassesImplementandoInterface()
        {
            var tipoComando = typeof(IComando);
            return Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => t.GetInterface(tipoComando.Name) == tipoComando && !t.IsInterface)
                        .Where(t => t.FullName != "projecteuler.Program");
        }

        public void ExecutarTodos()
        {
            if (!Exercicios.Any())
            {
                Console.WriteLine("Nenhum exercício implementando a interface para executar.");
            }
            foreach (var exercicio in Exercicios)
            {
                Console.WriteLine("Executando: " + exercicio.GetType().Name);
                exercicio.Executar();
                Console.WriteLine();
            }
        }
    }
}
