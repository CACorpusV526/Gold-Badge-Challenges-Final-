using System;
using System.Collections.Generic;
using _02_Claims_Challenge_Repo_;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Challenge_Unit_Test_
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void TestingAddToList()
        {
            ClaimsRepo claimsRepo = new ClaimsRepo();
            Claims testClaim = new Claims(9, ClaimType.Home, "House Fire", 75000.00, new DateTime(2020, 11, 21), new DateTime(2020, 12, 01), true);

            claimsRepo.AddClaimToList(testClaim);

            List<Claims> claimsList = claimsRepo.GetClaimsList();

            bool claimIDIsEqual = false;

            foreach (Claims claim in claimsList)
            {
                if (claim.ClaimID == testClaim.ClaimID)
                {
                    claimIDIsEqual = true;
                    break;
                }
            }
            Assert.IsTrue(claimIDIsEqual);
        }

        [TestMethod]
        public void TestingGetList()
        {
            ClaimsRepo claimsRepo = new ClaimsRepo();

            List<Claims> claimsList = claimsRepo.GetClaimsList();

            Assert.IsNotNull(claimsList);
        }

        [TestMethod]
        public void TestingViewByID()
        {
            ClaimsRepo claimsRepo = new ClaimsRepo();
            Claims testClaim = new Claims(9, ClaimType.Home, "House Fire", 75000.00, new DateTime(2020, 11, 21), new DateTime(2020, 12, 01), true);

            claimsRepo.AddClaimToList(testClaim);

            List<Claims> claimsList = claimsRepo.GetClaimsList();

            foreach (Claims claim in claimsList)
            {
                if (claim.ClaimID == testClaim.ClaimID)
                {
                    Assert.IsTrue(testClaim.ClaimID == 9);
                }
            }
        }

        [TestMethod]
        public void TestingWorkedOnClaim()
        {
            ClaimsRepo claimsRepo = new ClaimsRepo();
            Claims testClaim = new Claims(9, ClaimType.Home, "House Fire", 75000.00, new DateTime(2020, 11, 21), new DateTime(2020, 12, 01), true);

            claimsRepo.AddClaimToList(testClaim);
            claimsRepo.WorkedOnClaim(9);

            List<Claims> claimsList = claimsRepo.GetClaimsList();

            bool wasDeleted = true;

            foreach (Claims claim in claimsList)
            {
                if (claim.ClaimID == 9 || testClaim.ClaimID == 9)
                {
                    wasDeleted = false;
                    break;
                }
            }
            Assert.IsTrue(wasDeleted);
        }
    }
}
