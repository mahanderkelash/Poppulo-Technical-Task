using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoppuloTechnicalTask.Models.InventoryCategory
{
    public class MinMaxPrice
    {
        [Required(ErrorMessage = "Please provide Min Price", AllowEmptyStrings = false)]
        [Display(Name = "Min Price")]
        public double MinPrice { get; set; }
        [Required(ErrorMessage = "Please provide Max Price", AllowEmptyStrings = false)]
        [Display(Name = "Max Price")]
        public double MaxPrice { get; set; }
    }
}
