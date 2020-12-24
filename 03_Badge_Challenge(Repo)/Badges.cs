using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Challenge_Repo_
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public string AccessibleDoors { get; set; }

        public Badges() { }

        public Badges (int badgeID, string accessibleDoors)
        {
            BadgeID = badgeID;
            AccessibleDoors = accessibleDoors;
        }
    }
}
