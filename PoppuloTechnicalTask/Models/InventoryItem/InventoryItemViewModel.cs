using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoppuloTechnicalTask.Models.InventoryCategory;

namespace PoppuloTechnicalTask.Models.InventoryItem
{
    public class InventoryItemViewModel
    {
        public SelectList Categories { get; set; }

        public InventoryCategory.InventoryItem InventoryItem { get; set; }
        public string ErrorMessage { get; set; }
    }
}
