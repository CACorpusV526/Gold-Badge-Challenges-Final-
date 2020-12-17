using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Challenge_Repo_
{
    public class MenuRepo
    {
        private List<Menu> _listOfMeals = new List<Menu>();

        public void AddMealToMenu(Menu meal)
        {
            _listOfMeals.Add(meal);
        }

        public List<Menu> GetMenu()
        {
            return _listOfMeals;
        }

        public bool DeleteMenuItem(int mealNumber)
        {
            Menu meal = GetMealByNumber(mealNumber);

            if (meal == null)
            {
                return false;
            }

            int initialCount = _listOfMeals.Count;
            _listOfMeals.Remove(meal);

            if (initialCount > _listOfMeals.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Menu GetMealByNumber(int mealNumber)
        {
            foreach(Menu meal in _listOfMeals)
            {
                if (meal.MealNumber == mealNumber)
                {
                    return meal;
                }
            }

             return null;
        }
    }
}
