using BisleriumCafe.Data.Model;

public class PlaceOrderModel
{
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public string CoffeeType { get; set; }
    public string Size { get; set; }
    public string CustomerType { get; set; }
    public List<String> SelectedAddonNames { get; set; }

    public string TotalPrice { get; set; }

    public int PurchasesCounter { get; set; }
}



/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Data.Model
{
    public class PlaceOrderModel
    {
        [Required(ErrorMessage = "Customer Name is required")]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]  // Annotation to ensure a valid phone number is provided.
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Coffee Type is required")]
        [Display(Name = "Coffee Type")]
        public string CoffeeType { get; set; }

        [Required(ErrorMessage = "Size is required")]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Customer Type is required")]
        [Display(Name = "Customer Type")]
        public string CustomerType { get; set; }



        // This property represents a list of hobbies associated with the form.
        public List<AddOns> AddOns { get; set; }
    }
}


*/