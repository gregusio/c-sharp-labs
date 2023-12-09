using System.Reflection;
using System.Text.RegularExpressions;
using Common;

namespace Factory
{

    public class Program
    {
        public static void Main(string[] args)
        {
            for (var i = 0; i < args.Length - 1; i++)
            {
                var path = args[i++];
                var title = args[i];
                var assembly = Assembly.LoadFile(path);
                if (path.Contains("BeerProcessor"))
                {
                    Type t = assembly.GetType("BeerProcessor.BeerAssignment")!;
                    if(Activator.CreateInstance(t)! is IAssignment assignment)
                    {
                        assignment.Title = title;
                        assignment.Process();
                    }
                }
                else if (path.Contains("SandwichProcessor"))
                {
                    Type t = assembly.GetType("SandwichProcessor.SandwichAssignment")!;
                    if (Activator.CreateInstance(t) is IAssignment assignment)
                    {
                        assignment.Title = title;
                        assignment.Process();
                    }
                }
            }
        }
    }
}