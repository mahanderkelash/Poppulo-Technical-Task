using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoppuloTechnicalTask.Models.InventoryCategory
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please provide CategoryName", AllowEmptyStrings = false)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

     
    }
}
