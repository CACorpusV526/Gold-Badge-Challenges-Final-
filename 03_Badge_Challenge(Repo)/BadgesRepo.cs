using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Challenge_Repo_
{
    public class BadgesRepo
    {
        private Dictionary<int, Badges> _badges = new Dictionary<int, Badges>();
        private Badges newBadge = new Badges() { };
       
        public void AddABadge(Badges newBadge)
        {
            _badges.Add(newBadge.BadgeID, newBadge);
        }

        public Dictionary<int, Badges> GetBadges()
        {
            return _badges;
        }

        public bool UpdateBadge(int id, Badges newBadge)
        {
            Badges oldBadge = GetBadgeByID(id);

            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.AccessibleDoors = newBadge.AccessibleDoors;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveADoor(int id)
        {
            Badges badge = GetBadgeByID(id);

            if (badge == null)
            {
                return false;
            }

            int startCount = _badges.Count;
            _badges.Remove(badge.BadgeID);

            if (startCount > _badges.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Badges GetBadgeByID(int id)
        {
            Badges outBadge = new Badges();
            foreach (KeyValuePair<int, Badges> badges in _badges)
            {
                if (_badges.ContainsKey(id))
                {
                    return outBadge;
                }
            }
            return null;
        }
    }
}

