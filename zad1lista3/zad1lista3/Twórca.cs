using System;
using System.Collections.Generic;
using zad1lista3;

namespace zad1lista3
{
    public class Tworca
    {
        // Tworzenie delegata nowego obserwatora
        public delegate void nowy_obserwator_delegat(Obserwator He);
        // i eventu do tego obserwatora
        public event nowy_obserwator_delegat nowy_obserwator_stworzony;
        public delegate void przedstaw_sie_delegacie();
        public event przedstaw_sie_delegacie przedstaw_sie_stworzony;

        public List<Obserwator> them;
        // KONSTRUKTOR
        public Tworca()
        {
            them = new List<Obserwator>();
        }
        // Nowy obserwator
        public void stworz_nowy_obserwator()
        {
            // tworzenie nowego obserwatora
            Obserwator obs = new Obserwator();
            them.Add(obs);
            nowy_obserwator_stworzony(obs);
       
            // Obserwator sie przedstawia
            przedstaw_sie_stworzony();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Tworca tworca = new Tworca();
        for (int i = 0; i <= 5; i++)
        {
            Console.WriteLine("\n----------krok {0}----------\n", i.ToString());
            tworca.stworz_nowy_obserwator();
        }
    }
}

