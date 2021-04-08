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
        private Dictionary<Type, string> Respostas { get; init; }

        ILog Log;

        public Executor()
        {
            Exercicios = new List<IComando>();
            Respostas = new Dictionary<Type,string>();
            Log = LogFactory.CreateLog();

            IEnumerable<Type> classes = BuscarClassesImplementandoInterface();

            
            foreach (var classe in classes)
            {
                var objeto = Activator.CreateInstance(classe, Log);
                IComando comando = objeto as IComando;
                Exercicios.Add(comando);
            }
        }

        private static IEnumerable<Type> BuscarClassesImplementandoInterface()
        {
            var tipoComando = typeof(IComando);
            return Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => t.GetInterfaces().Contains(typeof(IComando)) && !t.IsInterface);
        }

        public void ExecutarTodos()
        {
            Respostas.Clear();
            if (!Exercicios.Any())
            {
                Log.Informacao("Nenhum exercício implementando a interface para executar.");
            }
            foreach (var exercicio in Exercicios)
            {
                Log.Informacao("Executando: " + exercicio.GetType().Name);
                var resposta = exercicio.Resolver();
                Respostas.Add(exercicio.GetType(), resposta);
                Console.WriteLine();
            }
        }

        //public string ObterResposta(Type comando)
        //{
        //    var tipo = typeof(IComando);
        //    if (comando.GetInterfaces().Contains(comando))
        //    {
        //        throw new ArgumentException("O tipo informado não implementa a interface " + tipo.FullName);
        //    }
        //    var saida = Respostas[comando];
        //    return saida;
        //}

        //public string ObterTodasRespostas()
        //{
        //    var saida = "Respostas..." + Environment.NewLine;
        //    foreach (var resposta in Respostas)
        //    {
        //        saida += $"Exercicio: {resposta.Key} Valor: {resposta.Value}{Environment.NewLine}";
        //    }
        //    return saida;
        //}
    }
}
