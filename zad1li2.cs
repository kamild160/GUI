using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{

    class Lista
    {
        int[] tab;


        public Lista(int k)
        {
            tab = new int[k];
            Random randNum = new Random();
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = randNum.Next(0, 100);
            }

        }

        public Lista()
        {


            Random rnd = new Random();
            int r = rnd.Next(1, 5);
            int[] tab1;

            tab1 = new int[r];
            for (int i = 0; i < tab1.Length; i++)
            {
                tab1[i] = rnd.Next(0, 100);
            }

        }

        public override string ToString()
        {

            String lista = "{ ";
            for (int i = 0; i < tab.Length - 1; i++)
            {
                lista += tab[i] + " ";
            }

            lista += "}";
            return lista;
        }

    }

    public class Lista1 : Lista, IComparable<Lista2>
    
    {
        public Lista1(int size) : base(size) { }
        public Lista1() : base() { }
        // pokazanie ze ta klasa ma dziedziczyć konstruktory z klasy Lista
        public int CompareTo(Lista1 that)
        {
            if (that == this) 
                return 0;

            else if (that == null) 
                return 1;
           
             for (int i = 0; i < this.tab.Count && i < that.tab.Count; i++)
            {
                if (this.tab[i] > that.tab[i])

                    return 1;

                else if (this.tab[i] < that.tab[i])

                    return -1;
            }


            return that.tab.Count > this.tab.Count ? -1 : 1;
        }

        public int CompareTo(Lista2 other)
        {
            throw new NotImplementedException();
        }
    }
    public class Lista2 : Lista, IComparable<Lista2>
    {
        public Lista2(int size) : base(size) { }

        public Lista2() : base() { }

        public int CompareTo(Lista2 that)
        {

            if (this.tab.Count > that.tab.Count)

                return 1;

            else if (this.tab.Count < that.tab.Count)

                return -1;

            for (int i = 0; i < that.tab.Count && i < this.tab.Count; i++)
            {
                if (this.tab[i] > that.tabi])
                   
                     return 1;

                else if (this.tab[i] < that.tab[i])
                   
                     return -1;
            }
        }
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
