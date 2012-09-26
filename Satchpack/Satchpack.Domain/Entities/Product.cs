using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Satchpack.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage="")]
        public string Name { get; set; }

        [Required(ErrorMessage = "")]
        public string Description { get; set; }

        [Required(ErrorMessage = "")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "")]
        public double Price { get; set; }

        [Required(ErrorMessage = "")]
        public double Weight { get; set; }
    }
}
