using _03_Badge_Challenge_Repo_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Challenge_Console_
{
    class BadgeUI
    {
        private BadgesRepo _badgesRepo = new BadgesRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Personel, What is on the agenda for today?\n\n" +
                    "1. Add A Badge\n" +
                    "2. Edit A Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit Program");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        ChangeABadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Have a safe day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select from the list given.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        private void AddABadge()
        {
            Console.Clear();
            Badges newBadge = new Badges();

            Console.WriteLine("Enter the ID Number for this Badge:");
            string badgeIDAsString = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeIDAsString);

            Console.WriteLine("Enter the doors you would like this Badge to have access to:");
            newBadge.AccessibleDoors = Console.ReadLine();

            Console.WriteLine("Any other doors? (y/n)");
            string additionalDoor = Console.ReadLine().ToLower();
            _badgesRepo.AddABadge(newBadge);

            while (additionalDoor == "y")
            {
                Console.WriteLine("Enter the doors you would like this Badge to have access to:");
                newBadge.AccessibleDoors = Console.ReadLine();
                Console.WriteLine("Any other doors? (y/n)");
                additionalDoor = Console.ReadLine();

            }
            if (additionalDoor == "n")
            {
                Console.WriteLine("All doors added");
                Console.Clear();
                Menu();
            }
        }

        private void ChangeABadge()
        {
            ViewAllBadges();

            Console.WriteLine("Enter the ID of the badge you want to update.");

            string oldBadgeID = Console.ReadLine();
            int oldBadgeIDAsInt = int.Parse(oldBadgeID);

            Badges newBadge = new Badges();

            Console.WriteLine("What would you like to do?\n\n" +
                "1. Remove A Door\n" +
                "2. Add A Door");
            string userInput = Console.ReadLine();


            if (userInput == "1")
            {
                Console.Clear();
                Console.WriteLine("Removing Doors");
                bool wasRemoved = _badgesRepo.RemoveADoor(oldBadgeIDAsInt);

                if (wasRemoved)
                {
                    Console.WriteLine("Doors were removed");
                }
                else
                {
                    Console.WriteLine("Doors have remained");
                }
            }
            else if (userInput == "2")
            {
                Console.Clear();
                Console.WriteLine("Enter the doors you would like this Badge to have access to:");
                newBadge.AccessibleDoors = Console.ReadLine();

                Console.WriteLine("Any other doors? (y/n)");
                string additionalDoor = Console.ReadLine().ToLower();
                _badgesRepo.AddABadge(newBadge);

                while (additionalDoor == "y")
                {
                    Console.WriteLine("Enter the doors you would like this Badge to have access to:");
                    newBadge.AccessibleDoors = Console.ReadLine();
                    Console.WriteLine("Any other doors? (y/n)");
                    additionalDoor = Console.ReadLine();

                }
                if (additionalDoor == "n")
                {
                    Console.WriteLine("All doors added");
                    Console.Clear();
                    Menu();
                }
                bool wasChanged = _badgesRepo.UpdateBadge(oldBadgeIDAsInt, newBadge);

                if (wasChanged)
                {
                    Console.WriteLine("Badge Updated");
                }
                else
                {
                    Console.WriteLine("Could not update");
                }
            }
        }

        private void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badges> dictofBadges = _badgesRepo.GetBadges();

            foreach (KeyValuePair<int, Badges> badge in dictofBadges)
            {
                Badges doors = badge.Value;
                Console.WriteLine($"ID #: {badge.Key} : Doors: {doors.AccessibleDoors}");

            }
        }
    }
}
