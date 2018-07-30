using System;
using System.Linq;
using System.Reflection;
using NoamIsTheBest.Commands;

namespace NoamIsTheBest
{
    public class ShoppingCartHandler
    {
        public bool Run()
        {
            var userInput = Console.ReadLine();
//            var userInput = "I want to buy Notebook"; // TODO: switch to readline
            if (userInput.ToLower().Equals("exit"))
                return false;

            var commands = Assembly.GetExecutingAssembly()
                                   .GetTypes()
                                   .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                                   .Select(Activator.CreateInstance).OfType<ICommand>();

            foreach (var command in commands)
            {
                if (command.IsRelevant(userInput))
                {
                    try
                    {
                        Console.WriteLine(command.Execute());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return true;
        }
    }
}