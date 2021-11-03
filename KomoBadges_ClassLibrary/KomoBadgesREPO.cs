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
        KomoBadges KomoBadges = new KomoBadges();
        Dictionary<int, string> newBadge = new Dictionary<int, string>();
        public void CreateBadge()
        {
            newBadge.Add(KomoBadges.BadgeID, KomoBadges.DoorNames);
        }
        public Dictionary<int, string> ViewBadge()
        {
            return newBadge;
        }
        public void RemoveBadge()
        {
            newBadge.Remove(KomoBadges.BadgeID);
        }


    }
}
