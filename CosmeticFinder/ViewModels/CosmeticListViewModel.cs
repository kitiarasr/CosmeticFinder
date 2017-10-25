using CosmeticFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.ViewModels
{
    public class CosmeticListViewModel : BaseViewModel
    {
        // to BaseViewModel

        // All fields in the given column
        public IEnumerable<CosmeticField> Fields { get; set; }

        public CosmeticFieldType Column { get; set; }
    }
}
