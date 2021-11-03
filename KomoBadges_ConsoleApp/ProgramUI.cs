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

        }
        private void BadgeID()
        {
            Dictionary<int, string> listOfBadges = komoBadgesREPO.ViewBadge();
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
                            Console.WriteLine("BadgeID already Exists! Please try again. Press anything to continue...");
                            Console.ReadKey();
                            run = false;
                        }
                        else 
                        {

                        }
                    }
                }
                catch
                {

                }
            }
        }
        private void EditBadge()
        {

        }
        private void ListOfBadges()
        {

        }
    }
}
