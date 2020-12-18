using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Challenge_Repo_
{
    class BadgesRepo
    {
        Dictionary<string, string> _badges = new Dictionary<string, string>();

        public void CreateABadge(string badgeID, string doorAccess)
        {
            _badges.Add(badgeID, doorAccess);
        }

        public Dictionary<string, string> GetBadgeDictionary()
        {
            return _badges;
        }

        public void UpdateBadge(string ogBadge, Badges newBadge)
        {
            Badges oldBadge = GetBadgeDictionary(ogBadge)
        }

        public Badges GetBadgeByID(string id)
        {
            for (int i = 0; i < _badges.Count; i++)
            {
                Console.WriteLine("Badge: {0}, Doors: {1}");
            }
        }
    }
}
