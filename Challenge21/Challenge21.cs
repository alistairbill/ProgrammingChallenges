/*
 * Challenge 21
 * Write a program that will store names into an array.
 * As a new name is entered it will be added to the end of the array.
 * The user can keep adding names until they enter the dummy value ‘exit’.
 * Once this has been done the program will display any duplicate names. 
 * E.g. 
 * Enter name: Bill
 * Enter name: Mary
 * Enter name: Anisha 
 * Enter name: Mary 
 * Enter name: exit
 * 
 * Mary is a duplicate. 
 * 
 * Extension
 * Display how many times each name has been duplicated 
 */

using System;
using System.Linq;
using System.Collections.Generic;

namespace Challenge21
{
    class Challenge21
    {
        static void Main(string[] args)
        {
            var names = new List<string>();
            do {
                Console.Write("\nEnter name: ");
                string name = Console.ReadLine();
                if (name != "exit")
                    names.Add(name);
                else
                    break;
            } while (true);
            var duplicates = from name in names
                             group name by name into list
                             let count = list.Count()
                             where (count > 1)
                             orderby count descending
                             select new { Name = list.Key, Count = count };
            Console.WriteLine("Duplicates:");
            foreach (var name in duplicates) {
                Console.WriteLine(name.Name + ": " + name.Count + " times");
            }
        }
    }
}
