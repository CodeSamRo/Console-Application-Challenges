using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomoBadges_ClassLibrary
{
    public class KomoBadges
    {
        //BadgeID, list of door name, name for badge
        public int BadgeID { get; set; }
        public string DoorNames { get; set; }
        public string BadgeName { get; set; }
        public KomoBadges()
        {

        }
        public KomoBadges(int badgeID, string doorNames, string badgeName)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
            BadgeName = badgeName;
        }
    }
}
