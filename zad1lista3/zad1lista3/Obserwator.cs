using System;
using System.Collections.Generic;

namespace zad1lista3
{
    public class Obserwator : IComparable<Obserwator>
    {
        // ZMIENNE STATYCZNE
        // zmianna wykorzystywana do tworzenia nazw
        private static int nazwa_tyl = 0;
        public static Random rand = new Random();
        // ZMIENNE DYNAMICZNE, pozwalaja na inizjalizacje zmiennych poprzez get i set
        public string nazwa { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double dystans { get; set; }
        public List<Obserwator> sasiedzi { get; set; }

        // KONSTRUKTOR
        public Obserwator()
        {
            this.nazwa = "Obs " + nazwa_tyl.ToString();
            this.x = rand.NextDouble();
            this.y = rand.NextDouble();
            this.sasiedzi = new List<Obserwator>();

            nazwa_tyl++;
        }
        // METODY
        // obliczanie dystansu miedzy punktami
        public void oblicz_dystans(Obserwator other)
        {
            this.dystans = Math.Sqrt(Math.Pow(this.x - other.x, 2) + Math.Pow(this.y - other.y, 2));
        }
        // Porównywarka
        public int CompareTo(Obserwator other)
        {
            if (this.dystans < other.dystans)
                return -1;
            else if (this.dystans > other.dystans)
                return 1;
            else
                return 0;
        }
        public void nowy_obserwator_event(Obserwator He)
        {
            // Jezeli lista jest pusta to nic sie nie dzieje
            // if (this.nazwa == He.nazwa)
            //     return;

            this.sasiedzi.Add(He);
            foreach (var sasiad in sasiedzi)
                sasiad.oblicz_dystans(this);
            sasiedzi.Sort();
            // wybieranie dwóch najbliszych, lub mniej najblizszych
            // if (sasiedzi.Count > 2)
            //     sasiedzi.RemoveAt (sasiedzi.Count - 1);
        }
        public void przedstaw_sie_event()
        {
            Console.WriteLine("Jestem " + nazwa + " - lista sąsiadów:");
            foreach (var sasiad in this.sasiedzi)
                Console.WriteLine("{0}\tx= {1:F3}\ty= {2:F3}\todl={3:F3}", sasiad.nazwa, sasiad.x, sasiad.y, sasiad.dystans);
            Console.WriteLine("");
        }
    }
}

