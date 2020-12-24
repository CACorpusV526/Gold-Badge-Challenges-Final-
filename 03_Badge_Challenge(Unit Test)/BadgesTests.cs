using System;
using System.Collections.Generic;
using _03_Badge_Challenge_Repo_;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badge_Challenge_Unit_Test_
{
    [TestClass]
    public class BadgesTests
    {
        [TestMethod]
        public void TestingAddABadge()
        {
            BadgesRepo badgeRepo = new BadgesRepo();
            Badges testBadge = new Badges(1, "C4");

            badgeRepo.AddABadge(testBadge);

            Dictionary<int, Badges> testDict = badgeRepo.GetBadges();

            bool badgeIdIsEqual = false;

            foreach (KeyValuePair<int, Badges> badge in testDict)
            {
                if(badge.Key == 1)
                {
                    badgeIdIsEqual = true;
                    break;
                }
                Assert.IsTrue(badgeIdIsEqual);
            }
        }

        [TestMethod]
        public void TestGetBadgeByID()
        {
            BadgesRepo badgeRepo = new BadgesRepo();
            Badges testBadge = new Badges(1, "C4");

            badgeRepo.AddABadge(testBadge);

            Dictionary<int, Badges> testDict = badgeRepo.GetBadges();

            foreach (KeyValuePair<int, Badges> badge in testDict)
            {
                if (badge.Key == testBadge.BadgeID)
                {
                    Assert.IsTrue(testBadge.BadgeID == 1);
                }
            }
        }

        [TestMethod]
        public void TestingUpdate()
        {
            BadgesRepo badgeRepo = new BadgesRepo();
            Badges testBadge = new Badges(1, "C4");

            bool changedResult = badgeRepo.UpdateBadge(2, testBadge);

            Assert.IsTrue(changedResult);
        }
    }
}
