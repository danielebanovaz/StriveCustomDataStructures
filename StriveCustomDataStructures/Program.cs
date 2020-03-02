using System;

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

                StriveArrayList myList = new StriveArrayList();
                myList.Insert(1000);
                myList.Insert(2000);
                myList.Insert(3000);
                myList.Insert(4000);
                myList.Insert(5000);
                myList.Insert(7);
                Console.WriteLine("is it full: " + myList.IsFull);
                myList.Insert(50, 2);
                //myList.Remove(0);
                //myList.Remove(myList.Count - 1);
                myList.Insert(10000);
                Console.WriteLine("is it full: " + myList.IsFull);
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

            /*
            // Faina's exercise
            int[] firstArray = new int[5];
            firstArray[0] = 4;
            for (int i = 1; i < firstArray.Length; i++)
            {
                firstArray[i] = new Random().Next(0, 101);
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                Console.Write(firstArray[i] + " | ");
            }
            Console.WriteLine("Second array");

            int[] secondArray = new int[firstArray.Length * 2];
            int newValue = new Random().Next(0, 101);
            secondArray[0] = firstArray[0] + 1;
            for (int i = 1; i <= firstArray.Length; i++)
            {
                secondArray[i] = i == firstArray.Length ? newValue : firstArray[i];
            }

            secondArray[7] = 1000;

            for (int i = 0; i < secondArray.Length; i++)
            {
                Console.Write(secondArray[i] + " | ");
            }*/
        }
    }
}
