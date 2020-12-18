using _02_Claims_Challenge_Repo_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_Claims_Challenge_Console_
{
    class ClaimsUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run()
        {
            SeedList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Agent, what would you like to do:\n" +
                    "1. See All Available Claims\n" +
                    "2. Work On Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit Program");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        WorkOnNextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        Console.WriteLine("See you tomorrow Agent!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose an option from the list.");
                        break;
                }

                Console.WriteLine("Press any key to continue with your choice...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            List<Claims> listofClaims = _claimsRepo.GetClaimsList();

            foreach (Claims claim in listofClaims)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Amount: {claim.ClaimAmount}\n" +
                    $"Date Of Accident: {claim.DateOfIncident}\n" +
                    $"Date Of Claim: {claim.DateOfClaim}\n" +
                    $"Is Valid: {claim.IsValid}\n\n");
            }
        }

        private void WorkOnNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Getting the next claim...\n");

            int currentClaim1 = 1;
            Claims claim = _claimsRepo.ViewNextClaimByID(currentClaim1);

            if (claim != null)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Amount: {claim.ClaimAmount}\n" +
                    $"Date Of Accident: {claim.DateOfIncident}\n" +
                    $"Date Of Claim: {claim.DateOfClaim}\n" +
                    $"Is Valid: {claim.IsValid}\n\n");

                Console.WriteLine("Do you want to work on this claim now (y/n):");
                string input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    Console.Clear();
                    Console.WriteLine("Okay here is your claim.");
                    Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Amount: {claim.ClaimAmount}\n" +
                    $"Date Of Accident: {claim.DateOfIncident}\n" +
                    $"Date Of Claim: {claim.DateOfClaim}\n" +
                    $"Is Valid: {claim.IsValid}\n\n");

                    _claimsRepo.WorkedOnClaim(claim.ClaimID);
                }
                else
                {
                    Console.Clear();
                    Menu();
                }
            }
            else
            {
                Console.WriteLine("No more claims for the day! Amazing job!");
            }
        }

        private void NewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            Console.WriteLine("Enter the claim ID:");
            string newClaimIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(newClaimIDAsString);

            Console.WriteLine("Enter the Claim Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");

            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            Console.WriteLine("Enter a Description for the claim:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Damag amount reported (Format 0.00):");
            string amountAsString = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(amountAsString);

            Console.WriteLine("Date of Accident (Format YYYY, MM, DD):");
            string dateOfIncidentString = Console.ReadLine();
            newClaim.DateOfIncident = Convert.ToDateTime(dateOfIncidentString);

            Console.WriteLine("Date of Claim (Format YYYY, MM, DD):");
            string dateOfClaimString = Console.ReadLine();
            newClaim.DateOfClaim = Convert.ToDateTime(dateOfClaimString);

            Console.WriteLine("Checking if claim is valid...\n");

            TimeSpan claimValid = newClaim.DateOfClaim - newClaim.DateOfIncident;

            if (claimValid.TotalDays > 30)
            {
                newClaim.IsValid = false;
            }
            else
            {
                newClaim.IsValid = true;
            }

            _claimsRepo.AddClaimToList(newClaim);
        }

        private void SeedList()
        {
            Claims claim1 = new Claims(1, ClaimType.Car, "Car accident on 465.", 400, new DateTime(2018, 04, 25), new DateTime(2018, 04,27), true);
            Claims claim2 = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            Claims claim3 = new Claims(3, ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            _claimsRepo.AddClaimToList(claim1);
            _claimsRepo.AddClaimToList(claim2);
            _claimsRepo.AddClaimToList(claim3);
        }
    }
}
