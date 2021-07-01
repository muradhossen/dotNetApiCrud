using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRUD_BAL.ViewModels
{
    public class tblColdDrinksViewModel
    {

        public int intColdDrinksId { get; set; }
        [Required]
        [Display(Name = "Cold Drinks Name")]
        public string strColdDrinksName { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public decimal numQuantity { get; set; }
        [Required]
        [Display(Name = "Unit Price")]
        public decimal numUnitPrice { get; set; }

        public double dblTotalQuantityPrice { get; set; }
       
    }
    public class FoodName
    {
        public string strColdDrinksName { get; set; }
    }
}
