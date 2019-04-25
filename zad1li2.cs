using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{

    class Lista
    {
        int [] tab ;
        

        public Lista(int k)
        {   
            tab = new int[k];
            Random randNum = new Random();
            for (int i=0;i<tab.Length;i++)
            {
                tab[i] = randNum.Next(0, 100);
            }

        }

       public Lista()
        {
           

            Random rnd = new Random();
            int r=rnd.Next(1,5);
            int [] tab1;

            tab1 = new int[r];
            for (int i = 0; i < tab1.Length; i++)
            {
                tab1[i] = rnd.Next(0, 100);
            }

        }

        public override string ToString()
        {
            
            String lista="{ ";
            for ( int i=0; i< tab.Length - 1;i++)
            {
                lista += tab[i]+ " ";
            }
           
            lista += "}";
            return lista;
        }

    }

    class Lista1:Lista
    {
        IComparable<>;

    }

    class Lista2:Lista
    {

    }


    class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista(5);
            
            Console.Write(lista);
            Console.ReadKey();




        }
    }
}
