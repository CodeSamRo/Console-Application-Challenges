using KomoCafe_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomoCafe_ConsoleApp
{
    class ProgramUI
    {
        KomoCafeRepo komoCafeREPO = new KomoCafeRepo();
        public void Run()
        {
            RunMenu();
        }
        //Menu Method
        private void RunMenu()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                LineDash();
                DisplayMenu();
                LineDash();
                Menu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        EditMenu();
                        break;
                    case "2":
                        run = false;
                        break;
                    default:
                        Console.Clear();
                        DefaultMessage();
                        Console.ReadKey();
                        break;
                }
            }
                
        }
        //Menu Helper Method
        private void Menu()
        {
            List<KomoCafe> listOfMeals = komoCafeREPO.ViewMeal();
            foreach(KomoCafe komoCafe in listOfMeals)
            {
                DisplayMenuItem(komoCafe);
            }
        }
        private void DisplayMenuItem(KomoCafe komoCafe)
        {
            LineDash();
            Console.WriteLine("|{0}. {1} \n" +
                "|Description: {2}\n" +
                "|Ingredients: {3}\n" +
                "|Price: {4}\n" +
                "|_______________________________________________________________________________________________________________________\n",
                komoCafe.MealNumber, komoCafe.MealName, komoCafe.Description,
                komoCafe.Ingredients, komoCafe.Price);
        }
        //EditMenu Method
        private void EditMenu()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                DisplayEditMenu();
                LineDash();
                Menu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddToMenu();
                        break;
                    case "2":
                        RemoveFromMenu();
                        break;
                    case "3":
                        run = false;
                        break;
                    default:
                        Console.Clear();
                        DefaultMessage();
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddToMenu()
        {
            List<KomoCafe> listOfMeals = komoCafeREPO.ViewMeal();
            KomoCafe komoCafe = new KomoCafe();
            Console.Clear();
            DisplayEditMenu();
            LineDash();
            bool run = true;
            for (int i = 1; run == true; i++)
            {
                foreach(KomoCafe komoCafe1 in listOfMeals)
                {
                    if(i == komoCafe1.MealNumber)
                    {
                        i++;
                    }
                }
                komoCafe.MealNumber = i;
                Console.WriteLine("Type in Meal Name-");
                komoCafe.MealName = Console.ReadLine();
                LineDash();
                Console.WriteLine("Type in Description-");
                komoCafe.Description = Console.ReadLine();
                LineDash();
                Console.WriteLine("Type in Ingredients-");
                komoCafe.Ingredients = Console.ReadLine();
                LineDash();
                Console.WriteLine("Type in Price-");
                try
                {
                    komoCafe.Price = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please type in a number. Starting over.. Press anything to continue...");
                    komoCafeREPO.DeleteMeal(komoCafe);
                    Console.ReadKey();
                    run = false;
                }
                Console.Clear();
                komoCafeREPO.CreateMeal(komoCafe);
                Console.WriteLine("{0}. {1} has been created. Press anything to continue...",
                    komoCafe.MealNumber, komoCafe.MealName);
                Console.ReadKey();
                run = false;
            }
        }
        private void RemoveFromMenu()
        {
            Console.Clear();
            List<KomoCafe> listOfMeals = komoCafeREPO.ViewMeal();
            bool run = true;
            while (run)
            {
                Console.WriteLine(
                "___________________________________________\n" +
                "|Welcome to KomoCafe's Remove Menu,        |\n" +
                "|here you can REMOVE an item               |\n" +
                "|from the menu.                            |\n" +
                "|Please type in the Meal Number,           |\n" +
                "|you would like to remove.                 |\n" +
                "|__________________________________________|\n");
                int userInput = 0;
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                    foreach (KomoCafe komoCafe in listOfMeals)
                    {
                        if (userInput == komoCafe.MealNumber)
                        {
                            Console.Clear();
                            Console.WriteLine("Meal {0}. {1} has been deleted. Press anything to continue...", komoCafe.MealNumber, komoCafe.MealName);
                            komoCafeREPO.DeleteMeal(komoCafe);
                        }
                        else
                        {
                            Console.WriteLine("Meal does not exist.");
                        }
                    }
                }
                catch
                {
                    Console.Clear();
                    DefaultMessage();
                    Console.ReadKey();
                    run = false;
                }
                finally
                {
                    Console.ReadKey();
                    run = false;
                }
            }

        }
        //LineSaver Helper Methods
        private void DefaultMessage()
        {
            Console.WriteLine("Incorrect input! Please select the correct option.\n" +
                "Please type anything to continue...");
        }
        private void LineDash()
        {
            Console.WriteLine("________________________________________________________________________________________________________________________");
        }
        private void DisplayMenu()
        {
            Console.WriteLine(
             "___________________________________________\n" +
             "|Welcome to KomoCafe's Menu,               |\n" +
             "|here are your have options to select from.|\n" +
             "|Please choose between numbers 1-2.        |\n" +
             "|__________________________________________|\n" +
             "|1. Edit Menu                              |\n" +
             "|2. Close Menu                             |\n" +
             "|__________________________________________|\n");
        }
        private void DisplayEditMenu()
        {
            Console.WriteLine(
            "___________________________________________\n" +
            "|Welcome to KomoCafe's Edit Menu,          |\n" +
            "|here you can ADD/REMOVE to or             |\n" +
            "|from the menu.                            |\n" +
            "|Please choose between numbers 1-3.        |\n" +
            "|__________________________________________|\n" +
            "|1. Add to Menu                            |\n" +
            "|2. Remove from Menu                       |\n" +
            "|3. Back                                   |\n" +
            "|__________________________________________|\n");
        }
    }
}
