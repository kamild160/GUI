using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbe naturalną: ");
            string liczba = Console.ReadLine();
            int n = int.Parse(liczba);
            string result = "";
            for (int k = 1; k <= n; k++)
            {
                for (int a = 1; a <= n; a++)
                {
                    result += String.Format("{0,5}",a*k);
                }
                result += ("\n");
            }
            Console.Write(result);
            Console.ReadLine();
        }
        
    }
}
