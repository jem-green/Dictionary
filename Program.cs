using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            Console.WriteLine("count=" + d.Count);

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

            Console.WriteLine("Remove[1]=" + d.Remove(1));
            Console.WriteLine("Contains[1]=" + d.ContainsKey(1));
            Console.WriteLine("Contains[2]=" + d.ContainsKey(2));
            //Console.WriteLine("Contains[2,\"\"]=" + d.Contains(new KeyValuePair<int, string>(2, "")));
            //Console.WriteLine("Contains[2,\"start\"]=" + d.Contains(new KeyValuePair<int, string>(2, "start")));

            Console.WriteLine("count" + d.Count);
            Console.WriteLine("data[0]=" + d[0]);
            Console.WriteLine("data[2]=" + d[2]);
            //Console.WriteLine("data[2]=" + d[2]);

            foreach (int key in d.Keys)
            {
                Console.WriteLine("Enumerate keys=" + key);

            }

            foreach (string value in d.Values)
            {
                Console.WriteLine("Enumerate values=" + value);
            }

            foreach (KeyValuePair<int, string> keyValue in d)
            {
                Console.WriteLine("Enumerate by keyValue " + keyValue.Key + " " + keyValue.Value);
            }
            //System.Collections.Generic.Dictionary<int,string>.KeyCollection keys = d.Keys;
            //System.Collections.Generic.Dictionary<int, string>.ValueCollection values = d.Values;

            d.Add(1, "between");
            Console.WriteLine("Add out of sequence");
            foreach (KeyValuePair<int, string> keyValue in d)
            {
                Console.WriteLine("Enumerate by keyValue " + keyValue.Key + " " + keyValue.Value);
            }

            Console.WriteLine("Remove[1]=" + d.Remove(1));
            //Console.WriteLine("Remove[2,\"\"]=" + d.Remove(new KeyValuePair<int, string>(2, "")));
            //Console.WriteLine("Remove[2,\"start\"]=" + d.Remove(new KeyValuePair<int, string>(2, "start")));

            foreach (KeyValuePair<int, string> keyvalue in d)
            {
                Console.WriteLine("Enumerate by KeyValue " + keyvalue.Key + " " + keyvalue.Value);
            }

            Console.WriteLine("TryKeyValue[0]=" + d.TryGetValue(0, out string item));
            Console.WriteLine("value=" + item);

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

            Console.WriteLine("count=" + pd.Count);
            Console.WriteLine("data[0]=" + pd[0]);
            Console.WriteLine("data[1]=" + pd[1]);
            Console.WriteLine("data[2]=" + pd[2]);

            Console.WriteLine("Remove[1]" + pd.Remove(1));
            Console.WriteLine("Contains[1]=" + pd.ContainsKey(1));
            Console.WriteLine("Contains[2]=" + pd.ContainsKey(2));
            //Console.WriteLine("Contains[2,\"start\"]=" + pd.Contains(new KeyValuePair<int, string>(2, "start")));
            //Console.WriteLine("Contains[2,\"\"]=" + pd.Contains(new KeyValuePair<int, string>(2, "" )));

            Console.WriteLine("count" + pd.Count);
            Console.WriteLine("data[0]=" + pd[0]);
            Console.WriteLine("data[2]=" + pd[2]);
            //Console.WriteLine("data[2]=" + pd[2]);

            foreach (int key in pd.Keys)
            {
                Console.WriteLine("Enumerate keys=" + key);
            }

            foreach (string value in pd.Values)
            {
                Console.WriteLine("Enumerate values=" + value);
            }

            foreach (KeyValuePair<int, string> keyValue in pd)
            {
                Console.WriteLine("Enumerate by keyValue " + keyValue.Key + " " + keyValue.Value);
            }

            pd.Add(1, "between"); 
            Console.WriteLine("Add out of sequence");
            foreach (KeyValuePair<int, string> keyValue in pd)
            {
                Console.WriteLine("Enumerate by keyValue " + keyValue.Key + " " + keyValue.Value);
            }

            Console.WriteLine("Remove[1]=" + pd.Remove(1));
            //Console.WriteLine("Remove[2,\"\"]=" + pd.Remove(new KeyValuePair<int, string>(2, "")));
            //Console.WriteLine("Remove[2,\"start\"]=" + pd.Remove(new KeyValuePair<int, string>(2, "start")));

            foreach (KeyValuePair<int, string> keyValue in pd)
            {
                Console.WriteLine("Enumerate by keyValue " + keyValue.Key + " " + keyValue.Value);
            }

            Console.WriteLine("TryKeyValue[0]=" + pd.TryGetValue(0, out item));
            Console.WriteLine("value=" + item);

        }
    }
}
 