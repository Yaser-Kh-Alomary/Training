using DesignPrinciples_Apps.EncapsulateWhatVaries_V2;
using System;

namespace DesignPrinciplesApps // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = Pizza.Order("Chicken");

            Console.WriteLine(pizza);

            Console.ReadKey();
        }
    }
}