using System;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {          

            Dictionary<int, string> d = new Dictionary<int, string>();

            d.Add(0, "start");
            d.Add(1, "next");
            d.Add(2, "end");
            Console.WriteLine("count" + d.Count);

            Console.WriteLine("data[0]=" + d[0]);
            Console.WriteLine("data[1]=" + d[1]);
            Console.WriteLine("data[2]=" + d[2]);

            Console.WriteLine("Clear Dictionary");
            d.Clear();
            d.Add(0,"end");
            Console.WriteLine("data[0]=" + d[0]);
            d.Add(1,"next");
            d.Add(2,"start");

            Console.WriteLine("Update Dictionary");
            //d[1] = "to";
            d[1] = "between";

            Console.WriteLine("count" + d.Count);
            Console.WriteLine("data[0]=" + d[0]);
            Console.WriteLine("data[1]=" + d[1]);
            Console.WriteLine("data[2]=" + d[2]);

            d.Remove(1);

            Console.WriteLine("count" + d.Count);
            Console.WriteLine("data[0]=" + d[0]);
            Console.WriteLine("data[2]=" + d[2]);
            //Console.WriteLine("data[2]=" + d[2]);
            foreach (int key in d.Keys)
            {
                Console.WriteLine("Enumerate " + key);
            }

            Console.WriteLine("--------");
            PersistentDictionary<int, string> pd = new PersistentDictionary<int, string>(true);

            pd.Add(0,"start");
            pd.Add(1,"next");
            pd.Add(2,"end");
            Console.WriteLine("count" + pd.Count);
            Console.WriteLine("data[0]=" + pd[0]);
            Console.WriteLine("data[1]=" + pd[1]);
            Console.WriteLine("data[2]=" + pd[2]);

            Console.WriteLine("Clear Dictionary");
            pd.Clear();
            pd.Add(0,"end");
            Console.WriteLine("data[0]=" + pd[0]);
            pd.Add(1,"next");
            pd.Add(2,"start");


            Console.WriteLine("Update Dictionary");
            //pl[1] = "to";
            pd[1] = "between";

            Console.WriteLine("count" + pd.Count);
            Console.WriteLine("data[0]=" + pd[0]);
            Console.WriteLine("data[1]=" + pd[1]);
            Console.WriteLine("data[2]=" + pd[2]);

            pd.Remove(1);

            Console.WriteLine("count" + pd.Count);
            Console.WriteLine("data[0]=" + pd[0]);
            Console.WriteLine("data[2]=" + pd[2]);
            //Console.WriteLine("data[2]=" + pd[2]);

            foreach (int key in d.Keys)
            {
                Console.WriteLine("Enumerate " + key);
            }
        }
    }
}
