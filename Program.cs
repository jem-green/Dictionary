using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {          

            Dictionary<int, string> d = new Dictionary<int, string>();

            d.Add(1, "start");
            d.Add(2, "next");
            d.Add(3, "end");
            Console.WriteLine("count" + d.Count);

            Console.WriteLine("data[1]=" + d[1]);
            Console.WriteLine("data[2]=" + d[2]);
            Console.WriteLine("data[3]=" + d[3]);

            foreach (int key in d.Keys)
            {
                Console.WriteLine(key);
            }

            // Compare

            PersistentDictionary<int, string> pd = new PersistentDictionary<int, string>(true);

            pd.Add(1, "start");
            pd.Add(2, "next");
            pd.Add(3, "end");
            Console.WriteLine("count" + pd.Count);
            Console.WriteLine("data[1]=" + pd[1]);
            Console.WriteLine("data[2]=" + pd[2]);
            Console.WriteLine("data[3]=" + pd[3]);

            foreach (int key in pd.Keys)
            {
                Console.WriteLine(key);
            }

        }
    }
}
