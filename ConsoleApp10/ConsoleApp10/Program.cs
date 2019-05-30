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

    class Watcher
    {
        private double x;
        private double y;
        private int nameNumber;
        private List<Watcher> friends;

        public Watcher(int _nameNumber)
        {
            nameNumber = _nameNumber;
            x = RandomGenerator.RandomRoundDouble(5);
            y = RandomGenerator.RandomRoundDouble(5);
            friends = new List<Watcher>();
        }

        private double Distance(Watcher watcher)
        {
            return Math.Round(Math.Sqrt(Math.Pow((x - watcher.x), 2) + Math.Pow((y - watcher.y), 2)), 7);
        }
    
        public void Subscribe(Creator creator)
        {
            creator.watcherDelegate += new Creator.WatcherDelegate(OnNewWatcher);
        }

        public void OnNewWatcher(Watcher watcher)
        {
            if (friends.Contains(watcher)) return;
            if (friends.Count == 0) friends.Add(watcher);
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
                if (distance > distance2) return;
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
            foreach (Watcher watcher in friends)
            {
                Console.Write("Friend {0}: [x]: {1}  | [y]: {2}  | distance: {3} \n", count, watcher.x, watcher.y, Distance(watcher));
                count++;
            }
        }

    }

    class Creator
    {
        private int count = 0;
        private List<Watcher> watchers;

        public delegate void WatcherDelegate(Watcher watcher);
        public event WatcherDelegate watcherDelegate;

        public Creator()
        {
            watchers = new List<Watcher>();
        }

        public void Create()
        {
            Watcher nw = new Watcher(count++);
            watchers.Add(nw);
            if (watcherDelegate != null)
            {
                foreach (WatcherDelegate del in watcherDelegate.GetInvocationList() )
                {
                    del(nw);
                }
            }
            nw.Subscribe(this);

        }

        public void Display()
        {
            foreach( Watcher watcher in watchers)
            {
                watcher.Introduce();
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Creator creator = new Creator();
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
