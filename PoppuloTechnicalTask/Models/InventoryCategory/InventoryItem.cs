using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoppuloTechnicalTask.Models.InventoryCategory
{
    public class InventoryItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Please provide an Item Name", AllowEmptyStrings = false)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please provide item quantity")]
        [Display(Name = "Quantity")]
        public int ItemQuantity { get; set; }

        [Required(ErrorMessage = "Please provide item price")]
        [Display(Name = "Price")]
        public double ItemPrice { get; set; }

        public Category  Category { get; set; }
        public int  CategoryId { get; set; }
        public DateTime ItemEntryDate { get; set; }
    }
}
