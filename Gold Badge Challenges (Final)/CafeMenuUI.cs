using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenges__Final_
{
    class CafeMenuUI
    {
        public void Run()
        {
            OperationsMenu();
        }

        private void OperationsMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hey Boss, what would you like to do?\n" +
                    "1. Add/Create A Meal\n" +
                    "2. View All Current Meals Available\n" +
                    "3. 86 A Meal\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateAMenuItem();
                        break;
                    case "2":
                        ViewAllMenuItems();
                        break;
                    case "3":
                        ByeByeAMeal();
                        break;
                    case "4":
                        Console.WriteLine("Until Next Time, Boss");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("I don't know what you are doing...\nPlease choose a number from the list.");
                        break;
                }

                Console.WriteLine("Getting your choice...\n\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
