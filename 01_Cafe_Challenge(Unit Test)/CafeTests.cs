using System;
using System.Collections.Generic;
using _01_Cafe_Challenge_Repo_;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Challenge_Unit_Test_
{
    [TestClass]
    public class CafeTests
    {
        [TestMethod]
        public void TestingAddToMenu()
        {
            MenuRepo menuRepo = new MenuRepo();
            Menu testMeal = new Menu(4, "Bub", "Drink", "Soda", 99.99);

            menuRepo.AddMealToMenu(testMeal);

            List<Menu> mealMenu = menuRepo.GetMenu();

            bool mealNumberIsEqual = false;

            foreach(Menu meal in mealMenu)
            {
                if (meal.MealNumber == testMeal.MealNumber)
                {
                    mealNumberIsEqual = true;
                    break;
                }
            }
            Assert.IsTrue(mealNumberIsEqual);
        }

        [TestMethod]
        public void TestingGetMenu()
        {
            MenuRepo menuRepo = new MenuRepo();

            List<Menu> mealMenu = menuRepo.GetMenu();

            Assert.IsNotNull(mealMenu);
        }

        [TestMethod]
        public void TestingDeleteMethod()
        {
            MenuRepo menuRepo = new MenuRepo();
            Menu testMeal = new Menu(10, "Bub", "Drink", "Soda", 99.99);

            menuRepo.AddMealToMenu(testMeal);
            menuRepo.DeleteMenuItem(10);

            List<Menu> mealMenu = menuRepo.GetMenu();

            bool notDeleted = true;

            foreach (Menu meal in mealMenu)
            {
                if (meal.MealNumber == 10)
                {
                    notDeleted = false;
                    break;
                }
            }
            Assert.IsTrue(notDeleted);
        }

        [TestMethod]
        public void TestGetByID()
        {
            MenuRepo menuRepo = new MenuRepo();
            Menu testMeal = new Menu(10, "Bub", "Drink", "Soda", 99.99);

            menuRepo.AddMealToMenu(testMeal);

            List<Menu> mealMenu = menuRepo.GetMenu();

            foreach (Menu meal in mealMenu)
            {
                if (meal.MealNumber == testMeal.MealNumber)
                {
                    Assert.IsTrue(testMeal.MealNumber == 10);
                }
            }
        }
    }
}
