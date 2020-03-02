using System;
using System.Collections;
using System.Collections.Generic;

namespace StriveCustomDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                // Test some operations of our newly created StriveArrayList

                IStriveList myList = new StriveLinkedList();

                myList.Insert(1000);
                myList.Insert(2000);
                myList.Insert(3000);
                myList.Insert(4000);
                myList.Insert(5000);
                myList.Insert(7);
                //Console.WriteLine("is it full: " + myList.IsFull);
                myList.Insert(50, 2);
                myList.Remove(0);
                //myList.Remove(myList.Count - 1);
                myList.Insert(10000);
                //Console.WriteLine("is it full: " + myList.IsFull);
                myList.Insert(20000);


                Console.WriteLine("element at index 4: " + myList[4]);
                myList[4] = 2;
                Console.WriteLine("element at index 4: " + myList[4]);
                myList[13] = 2;
                Console.WriteLine("element at index 13: " + myList[13]);

            }
            catch (IndexOutOfRangeException e)
            {
                // Operate accordingly
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            finally
            {
                // Get executed no matter what happend before

                // Why? IE: To release resources
            }

            #region .NET System.Collections Examples

            // Examples of usage of the default System.Collections Data Structures
            // NOTE: they all involve boxing/unboxing, avoid using them
            ArrayList arrayList = new ArrayList();
            arrayList[0] = 1;
            arrayList[1] = "my dog";
            arrayList[2] = arrayList;
            ((string)arrayList[1]).Split('0');

            Stack stack = new Stack();

            Queue queue = new Queue();

            Hashtable hashtable = new Hashtable();
            hashtable.Add("pocket", "my pocket definition straight outta dictionary");

            #endregion .NET System.Collections Examples

            #region Our GENERIC StriveLinkedList

            StriveLinkedListGeneric<string> genericList = new StriveLinkedListGeneric<string>();
            genericList.Insert("dog");
            genericList[0].ToUpper();

            StriveLinkedListGeneric<float> genericListButOfFloats = new StriveLinkedListGeneric<float>();
            genericListButOfFloats.Insert(0.25f);
            genericListButOfFloats[0]++;

            StriveLinkedListGeneric<int> genericListButOfInts = new StriveLinkedListGeneric<int>();
            genericListButOfInts.Insert(5);
            genericListButOfInts[0]++;

            #endregion Our GENERIC StriveLinkedList

            #region .NET System.Collections.Generic Examples

            // Examples of usage of the default System.Collections.Generic Data Structures
            // NOTE: they are way better, please use them!

            LinkedList<int> frameworkLinkedList = new LinkedList<int>();
            Stack<string> frameworkStack = new Stack<string>();
            Queue<DateTime> frameworkQueue = new Queue<DateTime>();
            List<long> frameworkArrayList = new List<long>();
            Dictionary<string, float> frameworkDictionary = new Dictionary<string, float>();
            frameworkDictionary.Add("Aby", 43);
            frameworkDictionary.Add("Neha", 39);
            frameworkDictionary.Add("Diego", 42);
            //frameworkDictionary.Add(12, 39); // <- Not allowed by the compiler

            #endregion .NET System.Collections.Generic Examples
        }
    }
}
