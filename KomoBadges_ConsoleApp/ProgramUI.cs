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
            Console.Clear();
            Console.WriteLine("What would you like the badge ID to be...\n");
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
                try
                {
                    int userID = Convert.ToInt32(Console.ReadLine());
                    foreach (var badge in listOfBadges)
                    {
                        if (komoBadges.BadgeID == userID)
                        {
                            Console.Clear();
                            Console.WriteLine("BadgeID already Exists! Please try again. Press anything to continue...");
                            Console.ReadKey();
                            run = false;
                        }
                        else 
                        {
                            komoBadges.BadgeID = userID;
                        }
                    }
                    komoBadges.BadgeID = userID;
                    bool secondRun = true;
                    Console.WriteLine("What door should {0} have access to?", komoBadges.BadgeID);
                    string doorName = Console.ReadLine();               
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
                                string doorInput = Console.ReadLine();
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
                    run = false;
                }
                catch
                {
                    Console.Clear();
                    DefaultErrorMessage();
                    Console.ReadKey();
                }
            }
        }
        private void EditBadge()
        {

        }
        private void ListOfBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> listOfBadges = komoBadgesREPO.ViewBadge();
            Console.WriteLine("Badge#          Door Access");
            Dictionary<int, List<string>>.ValueCollection valueColl;
            foreach (KeyValuePair<int, List<string>> badge in listOfBadges)
            {
                valueColl = listOfBadges.Values;
                Console.WriteLine($"{badge.Key}            {ListofDoors(valueColl)}");
            }
            Console.ReadKey();
        }
        private string ListofDoors(Dictionary<int, List<string>>.ValueCollection valueColl)
        {
            string doors = null;
            foreach(List<string> door in valueColl)
            {
                doors = string.Join(",", door);
            }
            return doors;
        }
        private void DefaultErrorMessage()
        {
            Console.WriteLine("Please type in the correct input...");
        }
    }
}
