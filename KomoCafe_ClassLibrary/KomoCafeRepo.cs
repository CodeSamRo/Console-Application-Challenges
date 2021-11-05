using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomoCafe_ClassLibrary
{
    public class KomoCafeRepo
    {
        List<KomoCafe> komoCafeREPO = new List<KomoCafe>(); 
        public bool CreateMeal(KomoCafe meal)
        {
            int count = komoCafeREPO.Count;
            komoCafeREPO.Add(meal);
            bool wasAdded = komoCafeREPO.Count > count ? true : false;
            return wasAdded;
        }
        public List<KomoCafe> ViewMeal()
        {
            return komoCafeREPO;
        }
        public bool DeleteMeal(KomoCafe existingMeal)
        {
            bool result = komoCafeREPO.Remove(existingMeal);
            return result;
        }
    }
}
