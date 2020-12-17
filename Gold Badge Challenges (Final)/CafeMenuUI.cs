using _01_Cafe_Challenge_Repo_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenges__Final_
{
    class CafeMenuUI
    {
        private MenuRepo _mealRepo = new MenuRepo();

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

        private void CreateAMenuItem()
        {
            Console.Clear();
            Menu newMeal = new Menu();


            Console.WriteLine("What would you like to call this meal?");
            newMeal.MealName = Console.ReadLine();

            Console.WriteLine("What number will this meal be assigned?");
            string mealNumberAsString = Console.ReadLine();
            newMeal.MealNumber = int.Parse(mealNumberAsString);

            Console.WriteLine("Please describe this meal:");
            newMeal.Description = Console.ReadLine();

            Console.WriteLine("Please list the ingredients in this meal:");
            newMeal.Ingredients = Console.ReadLine();

            Console.WriteLine("How much will you charge for this meal? (Please use the format 0.00");
            string priceAsString = Console.ReadLine();
            newMeal.Price = double.Parse(priceAsString);

            _mealRepo.AddMealToMenu(newMeal);
        }
    }
}
