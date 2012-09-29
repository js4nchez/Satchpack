using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Satchpack.Domain.Entities
{
    public class Invoice : DAL_Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide the customer associated with this invoice.")]
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Please provide the shipping method for this invoice.")]
        public ShippingMethod ShippingMethod { get; set; }

        [Required(ErrorMessage = "Please provide the date this order was placed on.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Please provide the total price for this invoice.")]
        public double InvoiceTotal { get; set; }

        [Required(ErrorMessage = "Please provide the current status of this invoice.")]
        public InvoiceStatus InvoiceStatus { get; set; }

        public Invoice()
        {
            CreateSproc = "dbo.CreateInvoice";
            RetrieveSproc = "dbo.RetrieveInvoice";
            UpdateSproc = "dbo.UpdateInvoice";
            DeleteSproc = "dbo.DeleteInvoice";
        }
        public override List<SqlParameter> ToSqlParams()
        {
            return new List<SqlParameter>()
            {
                new SqlParameter("@id", Id),
                new SqlParameter("@customerId", Customer.Id),
                new SqlParameter("@shippingMethodId", ShippingMethod.Id),
                new SqlParameter("@orderDate", OrderDate),
                new SqlParameter("@invoiceTotal", InvoiceTotal),
                new SqlParameter("@invoiceStatusId", InvoiceStatus.Id)
            };
        }
    }
}
