using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test the standard Dictionary

            Dictionary<int, string> d = new Dictionary<int, string>();

            d.Clear();
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

            // Test the Persistent Dictionary


            PersistentDictionary<int, string> pd = new PersistentDictionary<int, string>(true);

            pd.Clear();
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

            // Test the PersistentDictionary private methods

            PersistentDictionary<int, string> ppd = new PersistentDictionary<int,string>(true);
            object obj = RunInstanceMethod(typeof(Dictionary.PersistentDictionary<int,string>), "Create", ppd, new object[2] { 0, "start" });
            obj = RunInstanceMethod(typeof(Dictionary.PersistentDictionary<int,string>), "Create", ppd, new object[2] { 1, "next" });
            obj = RunInstanceMethod(typeof(Dictionary.PersistentDictionary<int,string>), "Create", ppd, new object[2] { 2, "end" });
            obj = RunInstanceMethod(typeof(Dictionary.PersistentDictionary<int,string>), "Delete", ppd, new object[1] { 1 });
            obj = RunInstanceMethod(typeof(Dictionary.PersistentDictionary<int,string>), "Create", ppd, new object[2] { 1, "next" });
            obj = RunInstanceMethod(typeof(Dictionary.PersistentDictionary<int,string>), "Update", ppd, new object[2] { 1, "to" });
            obj = RunInstanceMethod(typeof(Dictionary.PersistentDictionary<int,string>), "Update", ppd, new object[2] { 1, "longer" });

            for (int i = 0; i < 3; i++)
            {
                obj = RunInstanceMethod(typeof(Dictionary.PersistentDictionary<int,string>), "Read", ppd, new object[1] { i });
                string s = obj.ToString();
                Console.WriteLine(s);
            }
            obj = RunInstanceMethod(typeof(Dictionary.PersistentDictionary<int,string>), "Close", ppd, null);

        }

        public static object RunStaticMethod(System.Type t, string strMethod, object[] aobjParams)
        {
            BindingFlags eFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            return RunMethod(t, strMethod, null, aobjParams, eFlags);
        }

        public static object RunInstanceMethod(System.Type t, string strMethod, object objInstance, object[] aobjParams)
        {
            BindingFlags eFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            return RunMethod(t, strMethod, objInstance, aobjParams, eFlags);
        }

        private static object RunMethod(System.Type t, string strMethod, object objInstance, object[] aobjParams, BindingFlags eFlags)
        {
            MethodInfo m;
            try
            {
                m = t.GetMethod(strMethod, eFlags);
                if (m == null)
                {
                    throw new ArgumentException("There is no method '" + strMethod + "' for type '" + t.ToString() + "'.");
                }

                object objRet = m.Invoke(objInstance, aobjParams);
                return objRet;
            }
            catch
            {
                throw;
            }
        }

    }
}
 