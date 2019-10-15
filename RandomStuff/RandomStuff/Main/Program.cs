using System;
using System.Collections.Generic;
using RandomStuff.Classes;
using System.Text.RegularExpressions;

namespace RandomStuff.Main
{
    class Program
    {// list of programs that can be run
        static List<Tuple<int, string, string, bool, UniqueCharacters>> AvailablePrograms = new List<Tuple<int, string, string, bool, UniqueCharacters>> {
            new Tuple<int, string, string, bool, UniqueCharacters>(0, "IsUnique", "Checks if a string contains all unique characters", true, new UniqueCharacters()) };

        static void Main(string[] args)
        {

            //string test = "";
            //UniqueCharacters activeprogram = new UniqueCharacters(test);

            //Console.WriteLine(activeprogram.IsUnique());

            DisplayDescription();
            DisplayProgramList();
            ReadInputKey();
        }

        // Displays the overall description of the program selector
        private static void DisplayDescription()
        {
            Console.WriteLine("Welcome to the program selector. Please choose the program you wish to run from the list below by entering its number into the console.");
        }

        // Displays the list of available programs as well as their descriptions
        private static void DisplayProgramList()
        {
            foreach(var item in AvailablePrograms)
            {
                Console.WriteLine("\n{0}. {1} --{2}", item.Item1, item.Item2, item.Item3);
            }
        }

        // Reads the input number from the list for the selected program
        private static void ReadInputKey()
        {//reads in the number from the console
            var input = Console.ReadLine();

            //checks validity of the input for numbers between 0 and 100
            try
            {
                int program_num = Convert.ToInt32(input);
                if(program_num < 0 || program_num > 100)
                {
                    Console.WriteLine("\nInvalid input. Pick a number from the list.");
                    DisplayProgramList();
                    ReadInputKey();
                }
                else if(AvailablePrograms[program_num].Item1 == program_num)
                {
                    RunSelectedProgram(program_num);
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("\nInvalid input. Try again idiot.");
                DisplayProgramList();
                ReadInputKey();
            }
            catch(ArgumentOutOfRangeException e1)
            {
                Console.WriteLine("\nInput out of range. Pick a number from the list idiot.");
                DisplayProgramList();
                ReadInputKey();
            }
            
        }

        //Executes the selected program from the list
        private static void RunSelectedProgram(int program_num)
        {
            AvailablePrograms[program_num].Item5.Initiate();
        }
    }
}
