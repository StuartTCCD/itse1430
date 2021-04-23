/*
 * ITSE 1430
 * Spring 2021
 * Sample Implementation
 * Stuart Beeby
 */
using System;

namespace MovieLibrary
{
    class Program
    {
        static void Main()
        {
            DisplayMainMenu();
        }

        private static void DisplayMainMenu()
        {
            Console.WriteLine("Move Library");
            Console.WriteLine("------------");

            Console.WriteLine("A) dd Movie");
            Console.WriteLine("Q) uit");

            string input;

            input = Console.ReadLine();
        }

        void DemonVariables()
        {
            string textInput;

            textInput = "Hello";
        }
    }
}
