using System;
using System.Threading.Tasks;

namespace CSharpPlayground
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var app = new App.App();
                await app.RunAsync(args);
            }
            catch (Exception e)
            {
                Console.WriteLine("=====================");
                Console.WriteLine("A Critical error occured:");
                Console.WriteLine(e.Message);
                Console.WriteLine("=====================");
            }
        } 
    }
};

