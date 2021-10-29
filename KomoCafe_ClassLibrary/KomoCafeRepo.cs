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
        public void CreateMeal(KomoCafe meal)
        {
            komoCafeREPO.Add(meal);
        }
        public List<KomoCafe> ViewMeal()
        {
            return komoCafeREPO;
        }
        public void DeleteMeal(KomoCafe existingMeal)
        {
            komoCafeREPO.Remove(existingMeal);
        }
    }
}
