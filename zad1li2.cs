using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2
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
            int tabLenght = tab.Length;
            if (tabLenght < 1) return "[]";
            if (tabLenght == 1) return "[" + tab[0] + "]";
            String tmp = "[";
            for (int i = 0; i < tabLenght - 1; i++)
            {
                tmp += tab[i] + ", ";
            }
            tmp += tab[tabLenght - 1] + "]";
            return tmp;
        }

        public int Length
        {
            get
            {
                return tab.Length;
            }
        }

        public int this[int i]
        {
            get
            {
                if (i < Length) return tab[i];
                else return 0;
            }
        }

    }


    class Lista1 : Lista, IComparable<Lista1>
    {
        public Lista1() : base() { }
        public Lista1(int n) : base(n) { }

        public int CompareTo(Lista1 other)
        {
            if (other == null)
                return 1;

            for (int i = 0; i < Math.Max(other.Length, Length); i++)
            {
                if (other.Length < i)
                    return 1;

                if (Length < i)
                    return -1;

                else if (other[i] > this[i])
                    return -1;

                else if (other[i] < this[i])
                    return 1;
            }
            return 0;
        }

    }

    class Lista2 : Lista, IComparable<Lista2>
    {
        public Lista2() : base() { }
        public Lista2(int n) : base(n) { }

        public int CompareTo(Lista2 other)
        {
            if (other == null)
                return 1;

            if (Length == other.Length)
            {
                for (int i = 0; i < Math.Max(other.Length, Length); i++)
                {
                    if (other.Length < i)
                        return 1;

                    if (Length < i)
                        return -1;

                    else if (other[i] > this[i])
                        return -1;

                    else if (other[i] < this[i])
                         return 1;
                }
            }
            if (Length > other.Length)
                return 1;

            else
                return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista(5);
            Console.Write(lista);

            List<Lista2> l2 = new List<Lista2>();
            l2.Add(new Lista2(0));
            for (int i = 0; i < 10; i++)
            {
                l2.Add(new Lista2());
            }
    


            List<Lista1> l1 = new List<Lista1>();
            l1.Add(new Lista1(0));
           


            Console.Read();

        }

    }
}
