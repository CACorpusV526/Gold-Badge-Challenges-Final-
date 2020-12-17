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
                    "3. View A Meal By Number\n" +
                    "4. 86 A Meal\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateAMenuItem();
                        Console.WriteLine("Creating/Adding new meal to menu...\n");
                        break;
                    case "2":
                        Console.WriteLine("Getting you choice...\n");
                        ViewAllMenuItems();
                        break;
                    case "3":
                        Console.WriteLine("Getting you choice...\n");
                        ViewMenuItemByName();
                        break;
                    case "4":
                        ByeByeAMeal();
                        break;
                    case "5":
                        Console.WriteLine("Until Next Time, Boss\n");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("I don't know what you are doing...\nPlease choose a number from the list.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
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

            Console.WriteLine("How much will you charge for this meal? (Please use the format 0.00)");
            string priceAsString = Console.ReadLine();
            newMeal.Price = double.Parse(priceAsString);

            _mealRepo.AddMealToMenu(newMeal);
        }

        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<Menu> listOfMeals = _mealRepo.GetMenu();

            foreach (Menu meal in listOfMeals)
            {
                Console.WriteLine("#" + meal.MealNumber + 
                    "\nMeal Name: " + meal.MealName +
                    "\nDescription: " + meal.Description +
                    "\nPrice: " + meal.Price);
            }
        }

        private void ViewMenuItemByName()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of the meal you'd like to see:");

            string mealNumberAsString = Console.ReadLine();
            int mealNumberAsInt = int.Parse(mealNumberAsString);

            Menu meal = _mealRepo.GetMealByNumber(mealNumberAsInt);

            if (meal != null)
            {
                Console.WriteLine($"#{meal.MealNumber}\n" +
                    $"Price: {meal.Price}\n" +
                    $"Meal Name: {meal.MealName}\n" +
                    $"Description: {meal.Description}\n" +
                    $"Ingredients: {meal.Ingredients}");
            }
            else
            {
                Console.WriteLine("No meal in the system by that name.");
            }
        }

        private void ByeByeAMeal()
        {
            ViewAllMenuItems();

            Console.WriteLine("Enter the number of the meal you'd like to 86");
            string input = Console.ReadLine();
            int inputAsInt = int.Parse(input);

            bool wasDeleted = _mealRepo.DeleteMenuItem(inputAsInt);

            if (wasDeleted)
            {
                Console.WriteLine("Meal was 86'd!");
            }
            else
            {
                Console.WriteLine("Meal will not leave.");
            }
        }
    }
}
