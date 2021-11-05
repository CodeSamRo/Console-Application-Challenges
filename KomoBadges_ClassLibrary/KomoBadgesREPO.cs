using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomoBadges_ClassLibrary
{
    public class KomoBadgesREPO
    {
        //create a dictionary of badges
        //key for the dictionary will be the badgeID
        //the value for the dictionary will be the list of door names
        Dictionary<int, List<string>> newBadge = new Dictionary<int, List<string>>();
        List<KomoBadges> KomoBadges = new List<KomoBadges>();
        public void CreateID(KomoBadges komoBadges)
        {
            KomoBadges.Add(komoBadges);
        }
        public void DeleteID(KomoBadges komoBadges)
        {
            KomoBadges.Remove(komoBadges);
        }

        public void CreateBadge(KomoBadges komoBadges)
        {
            newBadge.Add(komoBadges.BadgeID, new List<string>());
        }
        public void AddDoor(KomoBadges badgeID ,string door)
        {
            newBadge[badgeID.BadgeID].Add(door);
        }
        public void RemoveDoor(KomoBadges badgeID, string door)
        {
            newBadge[badgeID.BadgeID].Remove(door);
        }
        public Dictionary<int, List<string>> ViewBadge()
        {
            return newBadge;
        }
        public KomoBadges GetBadgeByID(int ID)
        {
            foreach (KomoBadges badges in KomoBadges)
            {
                if (ID == badges.BadgeID)
                {
                    return badges;
                }
            }
            return null;
        }
        public void RemoveBadge(KomoBadges komoBadges)
        {
            newBadge.Remove(komoBadges.BadgeID);
        }


    }
}
