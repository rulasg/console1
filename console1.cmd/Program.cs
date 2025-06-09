using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("console1.test")]
namespace console1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Hello, World! {string.Join(" ", args)}");
        }
    }
}