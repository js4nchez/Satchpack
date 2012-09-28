using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Satchpack.Domain.Entities
{
    public class Invoice : DAL_Object
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide the customer associated with this invoice.")]
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Please provide the shipping method for this invoice.")]
        public int ShippingMethodId { get; set; }

        [Required(ErrorMessage = "Please provide the date this order was placed on.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Please provide the total price for this invoice.")]
        public double InvoiceTotal { get; set; }

        [Required(ErrorMessage = "Please provide the current status of this invoice.")]
        public int InvoiceStatusId { get; set; }

        public override List<SqlParameter> ToSqlParams()
        {
            throw new NotImplementedException();
        }
    }
}
