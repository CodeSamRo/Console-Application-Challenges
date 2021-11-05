using KomoBadges_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomoBadges_ConsoleApp
{
    class ProgramUI
    {
        //create a new badge
        //update doors on an existing badge
        //delete all doors from eexisting badge
        //show a list with all badge numbers and door access
        KomoBadgesREPO komoBadgesREPO = new KomoBadgesREPO();
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("\n" +
                " /=============================================/\n" +
                "|Welcome to Komodo Insurance Badge Application|\n" +
                "|What would you like to do?                   |\n" +
                "|_____________________________________________\n" +
                "|1. Add a badge                               |\n" +
                "|2. Edit a badge                              |\n" +
                "|3. List all Badges                           |\n" +
                "|4. Exit                                      |\n" +
                " /============================================/");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListOfBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please type in one of the numbers listed");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void CreateBadge()
        {
            BadgeID();
            Console.WriteLine("\nPlease anything to continue...");
            Console.ReadKey();

        }
        private void BadgeID()
        {
            Dictionary<int, List<string>> listOfBadges = komoBadgesREPO.ViewBadge();
            KomoBadges komoBadges = new KomoBadges();
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("What would you like the badge ID to be...\n");
                try
                {
                    bool continueToRun = true;
                    int userID = Convert.ToInt32(Console.ReadLine());
                    foreach (var badge in listOfBadges)
                    {
                        if (listOfBadges.Keys.Contains(userID))
                        {
                            Console.Clear();
                            Console.WriteLine("BadgeID already Exists! Please try again. Press anything to continue...");
                            Console.ReadKey();
                            continueToRun = false;
                        }
                    }
                    if (continueToRun)
                    {
                        komoBadges.BadgeID = userID;
                        bool secondRun = true;
                        Console.WriteLine("What door should {0} have access to?", komoBadges.BadgeID);
                        string doorName = Console.ReadLine().ToUpper();
                        komoBadges.DoorNames = null;
                        komoBadgesREPO.CreateID(komoBadges);
                        komoBadgesREPO.CreateBadge(komoBadges);
                        komoBadgesREPO.AddDoor(komoBadges, doorName);
                        Console.WriteLine("Badge number {0} was created.", komoBadges.BadgeID);
                        while (secondRun)
                        {
                            Console.WriteLine("\nAny other doors? (Y/N)");
                            string userInput = Console.ReadLine().ToLower();
                            switch (userInput)
                            {
                                case "y":
                                    Console.WriteLine("\nWhat door should {0} have access to?\n", komoBadges.BadgeID);
                                    string doorInput = Console.ReadLine().ToUpper();
                                    komoBadgesREPO.AddDoor(komoBadges, doorInput);
                                    break;
                                case "n":
                                    secondRun = false;
                                    break;
                                default:
                                    Console.WriteLine("\nPlease type Y for Yes or N for No...\n");
                                    Console.ReadKey();
                                    break;
                               }

                        }
                    }
                    run = false;
                }
                catch
                {
                    DefaultErrorMessage();                   
                }
            }
        }
        private void EditBadge()
        {
            ListOfBadges();
            Console.WriteLine("Type in the Badge ID you would like to edit.");
            try
            {
                Dictionary<int, List<string>> listOfBadges = komoBadgesREPO.ViewBadge();
                int userInput = Convert.ToInt32(Console.ReadLine());
                KomoBadges komoBadges = komoBadgesREPO.GetBadgeByID(userInput);

                foreach (var badgeID in listOfBadges)
                {
                    if (userInput == badgeID.Key)
                    {
                        EditPropmt(komoBadges, listOfBadges);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("ID does not exist.");
                        Console.ReadKey();
                    }
                }
            }
            catch
            {
                DefaultErrorMessage();
            }

        }
        private void EditPropmt(KomoBadges komoBadges, Dictionary<int, List<string>> listOfBadges)
        {
            bool run = true;
            
            while (run)
            {
                Console.WriteLine("What would you like to do?\n" +
                "1. Remove a Door\n" +
                "2. Add a door\n" +
                "3. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("What door should we remove from {0}\n", komoBadges.BadgeID);
                        string removeDoor = Console.ReadLine().ToUpper();
                        foreach (var badge in listOfBadges)
                        {
                            if (badge.Value.Contains(removeDoor))
                            {
                                komoBadgesREPO.RemoveDoor(komoBadges, removeDoor);
                            }
                            else
                            {
                                Console.WriteLine("Door is not listed under {0}", komoBadges.BadgeID);
                            }
                        }
                        Console.WriteLine("Door has been removed. Press anything to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("\nWhat door should {0} have access to?\n", komoBadges.BadgeID);
                        string addDoor = Console.ReadLine().ToUpper();
                        foreach (var badge in listOfBadges)
                        {
                            if (badge.Value.Contains(addDoor))
                            {
                                Console.WriteLine("Door Already Exits.");
                                Console.ReadLine();
                            }
                            else
                            {
                                komoBadgesREPO.AddDoor(komoBadges, addDoor);
                            }
                        }
                        Console.WriteLine("Door has been added. Press anything to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        run = false;
                        break;
                    default:
                        DefaultErrorMessage();
                        break;
                }
            }
        }

        private void ListOfBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> listOfBadges = komoBadgesREPO.ViewBadge();
            List<string> valueColl;
            Console.WriteLine("Badge#          Door Access");
            foreach (KeyValuePair<int, List<string>> badge in listOfBadges)
            {
                valueColl = badge.Value;
                Console.WriteLine($"{badge.Key}            {ListofDoors(valueColl)}");
            }
            Console.ReadKey();
        }
        private string ListofDoors(List<string> valueColl)
        {
            string doors = null;
            foreach(string door in valueColl)
            {
                doors = string.Join(", ", door);
            }
            return doors;
        }
        private void DefaultErrorMessage()
        {
            Console.Clear();
            Console.WriteLine("Please type in the correct input...");
            Console.ReadKey();
        }
    }
}
