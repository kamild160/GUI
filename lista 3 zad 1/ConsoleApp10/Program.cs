using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp10
{

    class RandomGenerator
    {
        static Random rand = new Random();
        public static int RandomNumber(int min, int max)
        {
            return rand.Next(min, max + 1);
        }
 
        public static double RandomDouble()
        {
            return rand.NextDouble();
        }

        public static double RandomRoundDouble(int places)
        {
            return Math.Round(rand.NextDouble(), places);
        }
    }

    class Obserwator
    {
        private double x;
        private double y;
        private int nameNumber;
        private List<Obserwator> friends;

        public Obserwator(int _nameNumber)
        {
            nameNumber = _nameNumber;
            x = RandomGenerator.RandomRoundDouble(5);
            y = RandomGenerator.RandomRoundDouble(5);
            friends = new List<Obserwator>();
        }

        private double Distance(Obserwator watcher)
        {
            return Math.Round(Math.Sqrt(Math.Pow((x - watcher.x), 2) + Math.Pow((y - watcher.y), 2)), 7);
        }
    
        public void Subscribe(Twórca creator)
        {
            creator.watcherDelegate += new Twórca.WatcherDelegate(OnNewWatcher);
        }

        public void OnNewWatcher(Obserwator watcher)
        {
            if (friends.Contains(watcher)) 
            return;

            if (friends.Count == 0) 
                friends.Add(watcher);

            else if (friends.Count == 1)
            {
                double distance = Distance(watcher);

                if (distance < Distance(friends[0]))
                {
                    friends.Add(watcher);
                    friends[1] = friends[0];
                    friends[0] = watcher;
                }

                else friends.Add(watcher);
            }
            else
            {
                double distance1 = Distance(friends[0]);
                double distance2 = Distance(friends[1]);
                double distance = Distance(watcher);

                if (distance > distance2) 
                    return;

                if (distance < distance2 && distance > distance1) friends[1] = watcher;

                else
                {
                    friends[1] = friends[0];
                    friends[0] = watcher;
                }
            }
            
        }

        public void Introduce()
        {

            Console.WriteLine("\n Watcher {0}\n", nameNumber);
            int count = 0;
            foreach (Obserwator watcher in friends)
            {
                Console.Write("Friend {0}: [x]: {1}  | [y]: {2}  | distance: {3} \n", count, watcher.x, watcher.y, Distance(watcher));
                count++;
            }
        }

       
    }

    class Twórca
    {
        private int count = 0;
        private List<Obserwator> watchers;

        public delegate void WatcherDelegate(Obserwator watcher);
        public event WatcherDelegate watcherDelegate;

        public Twórca()
        {
            watchers = new List<Obserwator>();
        }

        public void Create()
        {
            Obserwator obs = new Obserwator(count++);
            watchers.Add(obs);
            if (watcherDelegate != null)
            {
                foreach (WatcherDelegate del in watcherDelegate.GetInvocationList() )
                {
                    del(obs);
                }
            }
            obs.Subscribe(this);

        }

        public void Display()
        {
            foreach( Obserwator watcher in watchers)
            {
                watcher.Introduce();
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Twórca creator = new Twórca();
            for(int i = 0; i<5 ; i++)
            {
                creator.Create();
                creator.Display();
                Console.WriteLine("\n ---------------------------------------------- \n");
                //Thread.Sleep(1000);
            }

            Console.ReadKey();
        }
    }
}
