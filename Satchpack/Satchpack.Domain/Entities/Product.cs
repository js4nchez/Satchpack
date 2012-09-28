using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Satchpack.Domain.Entities
{
    public class Product : DAL_Object
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a SKU for this product.")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Please provide a name for this product.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide a description for this product.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please provide a weight in lbs. for this product.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Please provide a price for this product.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please provide a color for this product")]
        public string Color { get; set; }

        public override List<SqlParameter> ToSqlParams()
        {
            throw new NotImplementedException();
        }
    }
}
