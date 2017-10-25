using CosmeticFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.ViewModels
{
    public class BaseViewModel
    {
        public List<CosmeticFieldType> Columns { get; set; }

        // View title
        public string Title { get; set; } = "";

        public BaseViewModel()
        {
            // Populate the list of all columns
            Columns = new List<CosmeticFieldType>();

            foreach (CosmeticFieldType enumVal in Enum.GetValues(typeof(CosmeticFieldType)))
            {
                Columns.Add(enumVal);
            }


        }
    }
}
