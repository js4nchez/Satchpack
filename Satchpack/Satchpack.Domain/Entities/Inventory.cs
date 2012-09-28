using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Satchpack.Domain.Entities
{
    public class Inventory : DAL_Object
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please provide the available quantity for this product.")]
        public int Quantity { get; set; }

        public override List<SqlParameter> ToSqlParams()
        {
            throw new NotImplementedException();
        }
    }
}