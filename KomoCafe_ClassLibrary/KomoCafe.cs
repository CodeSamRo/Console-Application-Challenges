using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomoCafe_ClassLibrary
{
    public class KomoCafe
    {
        //A meal number, meal name, description, list of ingredients, price
        public int MealNumber { get; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int Price { get; set; }
        public KomoCafe()
        {

        }
        public KomoCafe(int mealNumber, string mealName, string description, string ingredidents, int price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredidents;
            Price = price;
        }
    }
}
