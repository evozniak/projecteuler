using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace projecteuler
{
    public class Executor
    {
        private readonly ILogger _logger;
        private List<ICommand> Exercises { get; init; }
        private Dictionary<Type, string> Responses { get; init; }
        public Executor(ILogger logger)
        {
            _logger = logger;
            Exercises = new List<ICommand>();
            Responses = new Dictionary<Type, string>();

            IEnumerable<Type> exercises = FindExerciseClasses();


            foreach (var exercise in exercises)
            {
                var exerciseObject = Activator.CreateInstance(exercise, logger);
                ICommand comando = exerciseObject as ICommand;
                Exercises.Add(comando);
            }
        }

        private static IEnumerable<Type> FindExerciseClasses()
        {
            var tipoComando = typeof(ICommand);
            return Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => t.GetInterfaces().Contains(typeof(ICommand)) && !t.IsInterface);
        }

        public void MainLoop(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("Welcome to project Euler");
                System.Console.WriteLine("Please choose wich test you want to execute");
                System.Console.WriteLine("");
                var exercises = FindExerciseClasses();
                foreach (var exercise in exercises)
                {
                    System.Console.WriteLine(exercise.Name);
                }
                return;
            }
            if (args[0].ToLower() == "all")
            {
                RunAll();
                return;
            }
            foreach (var arg in args)
            {
                RunExercise(arg);
            }
        }

        public void RunExercise(string exersiceName)
        {
            System.Console.WriteLine("Running: " + exersiceName);
            var projectNamespace = typeof(Executor).Namespace;
            var className = projectNamespace + '.' + exersiceName;
            var exercise = Exercises.Where(e => e.ToString() == className).FirstOrDefault();
            var result = exercise.Resolve();
            System.Console.WriteLine(exersiceName + ": " + result);
        }

        public void RunAll()
        {
            Responses.Clear();
            if (!Exercises.Any())
            {
                Log.Information("There exercises found.");
            }
            foreach (var exercise in Exercises)
            {
                Log.Information("Running: " + exercise.GetType().Name);
                var response = exercise.Resolve();
                Responses.Add(exercise.GetType(), response);
                Console.WriteLine("....");
            }
        }
    }
}
