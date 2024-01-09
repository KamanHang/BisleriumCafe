using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Data.Model
{
    public class AddOns
    {
        // Unique identifier for each hobby, automatically generated.
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]  // Required attribute ensures that this Name field is mandatory.
        public string Name { get; set; }
        public string Price { get; set; }

    }
}
